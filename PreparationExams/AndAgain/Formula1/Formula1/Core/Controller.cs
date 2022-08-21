using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;
using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private IRepository<IPilot> pilotRepository;
        private IRepository<IRace> raceRepository;
        private IRepository<IFormulaOneCar> carRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            this.pilotRepository.Add(new Pilot(fullName));
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {

            if (type == nameof(Ferrari))
            {
                if (this.carRepository.FindByName(model) != null)
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
                }
                this.carRepository.Add(new Ferrari(model, horsepower, engineDisplacement));
                return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
            }
            else if (type == nameof(Williams))
            {
                if (this.carRepository.FindByName(model) != null)
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
                }
                this.carRepository.Add(new Williams(model, horsepower, engineDisplacement));
                return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
            }

            throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (this.raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            this.raceRepository.Add(new Race(raceName, numberOfLaps));
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (this.pilotRepository.FindByName(pilotName) == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (this.pilotRepository.FindByName(pilotName).CanRace)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if (this.carRepository.FindByName(carModel) == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            var car = this.carRepository.FindByName(carModel);
            this.pilotRepository.FindByName(pilotName).AddCar(car);
            this.carRepository.Remove(car);
            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (this.raceRepository.FindByName(raceName) == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidRaceName, raceName));
            }

            var pilot = this.pilotRepository.FindByName(pilotFullName);
            if (pilot == null)
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            if (!pilot.CanRace)
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            if (this.raceRepository.FindByName(raceName).Pilots.Any(p=>p.FullName==pilotFullName))
            {
                throw new InvalidOperationException(string.Format
                (ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            this.raceRepository.FindByName(raceName).AddPilot(this.pilotRepository.FindByName(pilotFullName));
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName,raceName);
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots == null || race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            race.TookPlace = true;
            race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3).First().WinRace();
            List<IPilot> top3Pilots = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps))
                .Take(3).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace, top3Pilots[0].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, top3Pilots[1].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotThirdPlace, top3Pilots[2].FullName, raceName));
            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            var racesExecuted = raceRepository.Models.Where(r => r.TookPlace);
            foreach (var race in racesExecuted)
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pilot in this.pilotRepository.Models.OrderByDescending(p => p.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
