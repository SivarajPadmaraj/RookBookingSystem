# API for fictional room booking system 

## Introduction

This solution implements an API for a fictional room booking system. Following actions are implemented under 3 controllers

### People Controller
* People controller manages person
    * Get /People  -  Retuns details of  Person based on search critriea       
    * Post /People -  Create person record in database from request body. Name of person is required  
    * Get /People/{id} - Returns Person details for the given id
    * Put /People/{id} - Update the person record from request body for the given id.
    * Delete /People/{id} - Delete person with given id. All Bookings related to the person will also be deleted
### Rooms
* Write a series of endpoints to manage rooms
    * Add rooms
        * Rooms must have a unique name
    * Update rooms    
    * Search for rooms
    * Delete rooms, optionally shifting all bookings to another specified room
### Bookings
* Write a series of endpoints to manage room bookings
    * Add a room booking 
        * A room booking can be for a variable length of time, but it can be at maximum 1 hour long
    * Remove a room booking
    * See what rooms are available for a given time period

