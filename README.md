![TournamentPro Logo](TourneyPro/AssetsFolder/TournamentProTransparent.png)

This is a tournament organizing web application designed for both tournament organizers and attendees. The primary function is for tournament organizers to be able to provide information as to when an event is taking place, what events will be held, etc. Users will be able to register for events, and have their attendance tracked.

## Table of Contents
* [Introduction](#introduction)
* [Technologies](#Technologies)
* [Using the Project](#using)
* [Functions](#functions)
* [Resources](#resources)

## Introduction
This was a project for the Red Badge of Eleven Fifty Academy, where the primary task was to build a n-tiered MVC application with multiple tables with relationships between them.

The overall theme of the project for myself was a tournament organizing application for the Super Smash Bros. competitive scene. The advantage to using MVC for this was to be able to give TO's (Tournament Organizers) a tool to be able to share information about their tournaments, and be able to receive feedback from attendees so that they may accurately account for the amount of people attending the tournament.

## Technologies

This project was created using:
* .NET Framework - MVC Web Application
* Visual Studio Community
* C# Programming Language
* GitHub to house a remote repository
* Azure to deploy the site

## Using the Project
To access this project, route to https://tournamentproservice.azurewebsites.net , create an account, and begin creating tournaments and events

Alternatively, you can go to this github repository, https://github.com/JosephHallam/TourneyPro , clone or download the project, and launch through visual studio.

## Functions

This Project contains the standard CRUD for SiteUsers, Events, Tournaments, and Attendances. Clicking on the tabs in the collapsable list in the navbar will direct you to each table's Index. 
In the Tournament Index, you are able to filter through tournaments by name, if you were searching for a certain event.
This Application also supports Image files for player profiles. Simply clicking on the file upload button in the register view will allow users to upload photos to the database, and are displayed in the details view for a user.

## Resources
- Uploading Images to MVC Project: https://www.c-sharpcorner.com/UploadFile/b696c4/how-to-upload-and-display-image-in-mvc/
- Adding a Search Bar to MVC Project (Note this is in .NET Core, not Framework) https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/search?view=aspnetcore-3.1
