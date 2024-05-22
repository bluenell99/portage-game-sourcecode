using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunPosition : MonoBehaviour
{


    [SerializeField] private Light _sun;

    private float longitude = -1.29f;
    private float latitude = 50.1f; 
    private int utcOffset = 1;

    
   private void Update()
   {
       Calculate();
   }

   private void Calculate()
   {
       DateTime now = DateTime.UtcNow.AddHours(utcOffset);

       // Julian Day Calculation
       int year = now.Year;
       int month = now.Month;
       int day = now.Day;
       int hour = now.Hour;
       int minute = now.Minute;
       int second = now.Second;
       
        int a = (14 - month) / 12;
        int y = year + 4800 - a;
        int m = month + 12 * a - 3;

        double julianDay = day + (153 * m + 2) / 5 + 365 * y + y / 4 - y / 100 + y / 400 - 32045 + (hour - 12) / 24.0 + minute / 1440.0 + second / 86400.0;

        // Julian Century Calculation
        double julianCentury = (julianDay - 2451545.0) / 36525.0;

        // Geometric Mean Longitude
        double meanLongitude = (280.46646 + julianCentury * (36000.76983 + julianCentury * 0.0003032)) % 360;

        // Geometric Mean Anomaly
        double meanAnomaly = 357.52911 + julianCentury * (35999.05029 - 0.0001537 * julianCentury);

        // Equation of Center
        double equationOfCenter = Math.Sin(Mathf.Deg2Rad * meanAnomaly) * (1.914602 - julianCentury * (0.004817 + 0.000014 * julianCentury)) +
                                   Math.Sin(Mathf.Deg2Rad * 2 * meanAnomaly) * (0.019993 - 0.000101 * julianCentury) +
                                   Math.Sin(Mathf.Deg2Rad * 3 * meanAnomaly) * 0.000289;

        // True Longitude and True Anomaly
        double trueLongitude = meanLongitude + equationOfCenter;
        double trueAnomaly = meanAnomaly + equationOfCenter;

        // Sun's Right Ascension and Declination
        double sinTrueLongitude = Math.Sin(Mathf.Deg2Rad * trueLongitude);
        double rightAscension = Math.Atan2(Math.Cos(Mathf.Deg2Rad * trueAnomaly), sinTrueLongitude);
        double declination = Math.Asin(Math.Sin(Mathf.Deg2Rad * trueAnomaly) * Math.Sin(Mathf.Deg2Rad * 23.4392911)); // Obliquity of the ecliptic

        // Greenwich Mean Sidereal Time
        double greenwichMeanSiderealTime = 280.46061837 + 360.98564736629 * (julianDay - 2451545.0) + 0.000387933 * julianCentury * julianCentury - julianCentury * julianCentury * julianCentury / 38710000.0;

        // Local Sidereal Time
        double localSiderealTime = greenwichMeanSiderealTime + longitude;

        // Hour Angle
        double hourAngle = localSiderealTime - rightAscension;

        // Calculate rotation based on sun position
        float azimuth = (float)(Math.Atan2(Math.Sin(Mathf.Deg2Rad * hourAngle), Math.Cos(Mathf.Deg2Rad * hourAngle) * Math.Sin(Mathf.Deg2Rad * latitude) - Math.Tan(Mathf.Deg2Rad * declination) * Math.Cos(Mathf.Deg2Rad * latitude)) * Mathf.Rad2Deg);
        float altitude = (float)(Math.Asin(Math.Sin(Mathf.Deg2Rad * latitude) * Math.Sin(Mathf.Deg2Rad * declination) + Math.Cos(Mathf.Deg2Rad * latitude) * Math.Cos(Mathf.Deg2Rad * declination) * Math.Cos(Mathf.Deg2Rad * hourAngle)) * Mathf.Rad2Deg);
      
        Quaternion rotation = Quaternion.Euler(90.0f - altitude, azimuth, 0.0f);

        _sun.transform.rotation = rotation;
   } 

}
