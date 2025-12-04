📘 DVLD – Driving License Management System

A Full C# WinForms + SQL Server Project

This repository contains the complete implementation of the DVLD (Driving License Management System) project, including all source code, database files, business logic layers, user controls, application workflows, and system modules.

The project is structured as a real-world WinForms application that manages people, users, driving license applications, tests, international licenses, and detaining/releasing processes. It follows a layered architecture with Business Layer, Data Access Layer, and Presentation Layer.

📌 Table of Contents

Project Overview

System Requirements & Features

Database Structure

Core Modules

Source Code Explanation

Downloads

Final Notes

🚀 Project Overview

The DVLD system manages all operations related to driving licenses, including:

Managing people and users

Creating and processing local and international driving license applications

Scheduling and handling driving tests (written, vision, street)

Renewing, replacing, detaining, and releasing licenses

Managing application types, test types, and license classes

Showing complete driver history and license information

The project demonstrates the building of a full enterprise-level system using C#, WinForms, multi-layer architecture, and SQL Server.

🧭 System Requirements & Features
People Management

Add, update, delete people

Manage country list

Person card & searchable person card

Person image management

Find person & show detailed information

List and filter all people

Users & Authentication

Add/edit system users

User card and info screens

Change password

Login system with permissions

User management screens

Application Types

Manage application types

Edit and list available types

Test Types

Manage test types

Edit and list test categories

License Applications
Local Driving License Applications

Add/update applications

Application info control and forms

List existing applications

International Driving License Applications

Add new international license applications

List international applications

Driving Tests

Schedule tests

Test appointment listing

Take tests and manage results

Retake failed tests

Drivers & Licenses

Issue license for the first time

Renew driving licenses

Replace lost or damaged licenses

Show license information

Driver license info controls

View driver license history

List all drivers

Detain & Release Licenses

Detain license

Release detained license

Manage detained licenses

🗄 Database Structure

The database includes complete structure and relationships required for the system.

Main Tables Include:

People

Countries

Users

Applications

Application Types

LocalDrivingLicenseApplications

License Classes

Test Types

Test Appointments

Tests

Drivers

Licenses

International Licenses

Detained Licenses

Each table contains relationships and constraints that match real-world driving license authority workflows.

📂 Source Code Explanation

The repository includes detailed breakdowns of all system components:

Main Form

UI navigation

Loading modules

Managing system-level interactions

Business & Data Access Layers

Encapsulation of rules

SQL operations

Entities and models

User Controls

Person card control

User card control

Driving license info controls

Filter controls

Application info controls

Test scheduling controls

Forms

Modular forms for every action

Add/update workflows

Display and search logic

Test and license management forms

📥 Downloads

The project bundle includes:

Source Code (C# WinForms – .NET Framework)

Database (latest version)

Project icons

Documentation files

Ensure you restore the database before running the solution.

🏁 Final Notes

This project represents a complete educational and practical implementation of a driving license management system. It demonstrates:

Clean architecture

Event-driven programming

Business/Data layer separation

Real-world workflows

Professional WinForms development
