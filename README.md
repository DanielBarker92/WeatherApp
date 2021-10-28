# WeatherApp

## Overview

The project consists of two parts.

1. An Azure Function HttpTrigger (API) that calls the OpenWeatherMap API and returns weather details.
2. A .Net Core MVC application that calls the API and displays the details on a basic MVC site.

## Setup

On first run you will need to enable both projects as Startup Projects. 

To do this you will need to:

1. Right click the solution in Visual Studio.
2. Select 'Set Startup Projects...'
3. Select the Multiple Projects radio button
4. Set the 'Action' for 'WeatherApp' and 'WeatherApp.Api' to 'Start'
5. Press Ok.
6. Press F5 (or run)

## Tests 

Unit tests and integration tests have been added where I think applicable. I've not done any end to end tests as I couldn't find a framework I was comfortable using. Previously I've used the Selenium.WebDriver package but didn't get a chance to add that here.

## Future Improvements & Notes

I would like to get a good React front-end working but the time didnt allow for it and I wanted to use something I was a bit more comfortable with that shows me ability a bit better. 

In total I think this took me somewhere in the region of 7-9 hours (I think) over the course of 3 days.