# Sophia_ERP_Ltd

# Employee Application Processing System - Technical Assessment

This repository contains problem statements and tasks for evaluating candidate technical skills across data manipulation, database schema design, SQL querying, and RESTful API architecture.



## QUESTION 1: Overdue Applications Calculation

### Problem Statement
You are given a list of employee applications, each containing a submission date (`submittedAt`) and processing duration (`processingDays`).

const applications = [
  { id: 1, submittedAt: "2024-10-01", processingDays: 5 },
  { id: 2, submittedAt: "2024-10-03", processingDays: 2 },
  { id: 3, submittedAt: "2024-10-05", processingDays: 10 }
];

Write a function that:

Calculates the expected completion date for each application (submittedAt + processingDays).

Filters and returns only applications that are overdue, assuming today's date is 2024-10-10.


Expected Output:
[
  { "id": 1, "expectedCompletion": "2024-10-06" },
  { "id": 2, "expectedCompletion": "2024-10-05" }
]

### Solution

Constraints:

No External Libraries: Rely only on native language utilities (e.g., standard Date APIs).

Code Clarity: Prioritize readable, maintainable code over overly concise solutions.




## QUESTION 2: Database Schema & Query Design

Scenario: 

You are designing the storage layer for a backend system managing employee applications.

Part A – SQL Schema Design:

Design two relational database tables (employees and applications) using PostgreSQL or MySQL syntax. Your design must include:

Primary keys (PK) for both tables.

Foreign key (FK) relationship linking applications to employees.

Application status tracking (e.g., Pending, Approved, Rejected).

Relevant audit timestamps (created_at, updated_at).


Part B – Write a SQL query that retrieves:

All Pending applications.

The applicant's full name.

Results ordered by submission date (oldest first).



### QUESTION 3: RESTful API Design

Scenario:

Design the backend API endpoints required to manage the lifecycle of employee applications (creation, retrieval, updates, and deletion).

Tasks:

Define the HTTP specifications for the following operations:

Submit Application: Receive and store a new employee application.

Retrieve Applications: Fetch all applications with support for query filters (e.g., by status or employee ID).

Update Application Status: Approve, reject, or modify an existing application's status.

Delete Application: Remove an application record by its unique identifier.