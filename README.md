# Inovatec-Process-Tracker

The goal of the project is Services and Applications monitoring. When a service go down, it is recorded in the database(MS SQL Server) and the email is automatically sent to the user. The user can subscribe or unsubscribe for receiving emails when server go down, also he can choose which services they want to track. All service information and history is displayed to the user via the mobile application. 

## Components of system

<b>
<p align="center"><img src="https://raw.githubusercontent.com/kovacevic-marko/Inovatec-Process-Tracker/master/Pictures/1.jpg" /></p>

Server:
<ul>
    <li>Database (Microsoft SQL Server)</li>
    <li>Data access (Entity Framework)</li>
    <li>Data collector (Windows service)</li>
    <li>Web API (ASP.NET)</li>
</ul> 

Client:
<ul>
    <li>Android and iOS mobile application (Xamarin Forms(</li>
</ul>

## Relational model of database

<p align="center"><img src="https://raw.githubusercontent.com/kovacevic-marko/Inovatec-Process-Tracker/master/Pictures/2.jpg" /></p>

## Client application

## 1. Homepage
<p align="center"><img src="https://raw.githubusercontent.com/kovacevic-marko/Inovatec-Process-Tracker/master/Pictures/3.jpg" /></p>
On this page user choose to manage settings of applications or to show clients.

## 2. Settings
<p align="center"><img src="https://raw.githubusercontent.com/kovacevic-marko/Inovatec-Process-Tracker/master/Pictures/4.jpg" /></p>
On this page user:
<ul>
    <li>Manage WebAPI URL</li>
    <li>Enter his email adress for subscrition on email notification service</li>
    <li>Enable or disable receiving emails when service or application go down</li>
</ul>

## 3. List of clients
<p align="center"><img src="https://raw.githubusercontent.com/kovacevic-marko/Inovatec-Process-Tracker/master/Pictures/5.jpg" /></p>
On this page user choose for which client want to see services and applications.

## 3.1 Services or applications
<p align="center"><img src="https://raw.githubusercontent.com/kovacevic-marko/Inovatec-Process-Tracker/master/Pictures/6.jpg" /></p>
On this application user choose services or applications

## 4. List of services
<p align="center"><img src="https://raw.githubusercontent.com/kovacevic-marko/Inovatec-Process-Tracker/master/Pictures/7.jpg" /></p>
On this page user:
<ul>
    <li>See all services for his client</li>
    <li>See service status for all services</li>
    <li>Enable or disable receiving emails for specific service</li>
</ul>

## 4.1 Service history
<p align="center"><img src="https://raw.githubusercontent.com/kovacevic-marko/Inovatec-Process-Tracker/master/Pictures/8.jpg" /></p>
On this page user see currently service status and log history for this service.


<br><br><br>
Release date: November 2017.
