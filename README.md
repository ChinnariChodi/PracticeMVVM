For creating data the use the below migrationscommand

Add-Migration Initialize -Project PatientApplication.Entity -StartupProject PatientApplication.Domain
Update-database

Aslo change the connectionString
