# Backend Refresher Training — BridgeLabz

## Day 1 | DB Programming

### 💡 Topics Covered
* **DBMS vs. RDBMS:** Relational vs. Non-Relational databases and when to use each.
* **Tools:** MS SQL Server & T-SQL introduction.
* **RDBMS Fundamentals:** Core concepts of database structure and management.

### 🛠️ Tasks Completed
* **Setup:** Configured MS SQL Server environment.
* **Design:** Sketched ER Diagram for Health Clinic App (*Patients, Doctors, Appointments*).
* **Code:** Wrote and pushed schema creation SQL scripts.
  
  

  # Day 2 | DB Programming & Indexing

## 📌 Progress Overview
* **Day 2**  **Topic:** Advanced RDBMS & Query Optimization | **Status:** ✅ Done

---

### 💡 Topics Covered
* **Database Concepts:** Entities, Attributes, Relationships, Cardinality, and Keys.
* **Indexes:** Clustered, Non-Clustered, Unique, and Composite Indexes.
* **Database Normalization:** 1NF, 2NF, 3NF, and BCNF principles.

### 🛠️ Tasks Completed
1. **Schema Extension:** Added a `rooms` table and created a `doctor_room` relationship to map doctor room assignments.
2. **Query Performance Analysis:** Executed on 3 `appointments` queries (No Index, Single-Column Index, Composite Index) and analyzed `type` and `rows` metrics.
3. **Normalization Audit:** Verified `patient_phones` against 1NF, 2NF, and 3NF with written justifications for each step.
4. **Covering Index Optimization:** Created a covering index for `doctor_id`, `appointment_date`, and `status`, verifying index usage (`Using index` in `Extra`) via `EXPLAIN`.

📁 **Files:** [`/Day-2`](./Day-2) directory (`Day2_Queries_and_EXPLAIN.sql`, Schema Updates, Normalization Notes).