﻿using ApiDotNet.Models.Entities;

namespace ApiDotNet
{
    public class CitiesDataStore
    {
        public List<CityDTO> CitiesList = new List<CityDTO>();

        //singleton pattern :use this static property to use 
        //this class throughout the project 
        public static CitiesDataStore citiesDataStoreInstance { get; } =
            new CitiesDataStore();
        public CitiesDataStore()
        {
            CitiesList = new List<CityDTO>()
            {
                new CityDTO(){Id=1, Name="Tehran",
                    Description="Iran's capital",
                PointsOfInterests=new List<PointsOfInterestDTO>()
                {
                    new PointsOfInterestDTO()
                  {
                      pointOfInterestId=1, Name="Baghe Shah",
                       Description="in down town"
                  },

                    new PointsOfInterestDTO()
                    {
                       pointOfInterestId=2, Name="Topkhane",
                       Description="in south of city"
                    }
                }
                },

                new CityDTO(){Id=2, Name="Berlin",
                    Description="Germany's capital"
                , PointsOfInterests=new List<PointsOfInterestDTO>()
                {
                    new PointsOfInterestDTO()
                    {
                        pointOfInterestId=3, Name="main church",
                        Description="very beautiful place",
                    },

                    new PointsOfInterestDTO()
                    {
                        pointOfInterestId=4, Name="main Dom",
                        Description="very beautiful place",
                    },
                } 
                },

                new CityDTO()
                {
                    Id=3, Name="London",
                    Description="England's capital",
                    PointsOfInterests= new List<PointsOfInterestDTO>()
                    {
                        new PointsOfInterestDTO()
                        {
                            pointOfInterestId=5, Name="main Bridge",
                            Description="build in 1798",
                             
                        },
                         new PointsOfInterestDTO()
                        {
                             pointOfInterestId=6, Name="main cathedra",
                            Description="build in 1548",
                        },
                    }

                },

            };
        }
    }
}
