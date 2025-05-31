![Oracle Logo](https://raw.githubusercontent.com/oracle/dotnet-db-samples/master/images/oracle-nuget.png) 
# Oracle.ManagedDataAccess 23.8.0
Release Notes for Oracle Data Provider for .NET, Managed Driver NuGet Package

March 2025

Managed Oracle Data Provider for .NET (ODP.NET) features optimized ADO.NET data access to the Oracle database for .NET Framework and is 100% managed code. ODP.NET allows developers to take advantage of advanced Oracle database functionality, including AI vectors, Real Application Clusters, Application Continuity, JSON Relational Duality, and Fast Connection Failover. 

This document provides information that supplements the [Oracle Data Provider for .NET (ODP.NET) documentation](https://docs.oracle.com/en/database/oracle/oracle-database/23/odpnt/index.html).

## Oracle .NET Links
* [Oracle .NET Home Page](https://www.oracle.com/database/technologies/appdev/dotnet.html)
* [GitHub - Sample Code](https://github.com/oracle/dotnet-db-samples)
* [ODP.NET Discussion Forum](https://forums.oracle.com/ords/apexds/domain/dev-community/category/odp-dot-net)
* [YouTube](https://www.youtube.com/user/OracleDOTNETTeam)
* [X (Twitter)](https://twitter.com/oracledotnet)
* [Email Newsletter Sign Up](https://go.oracle.com/LP=28277?elqCampaignId=124071&nsl=onetdev)

## New Features
* AI: Oracle Sparse Vector and Dense Vector Data Types
* OracleDataSource (Oracle DbDataSource)
* SQL Injection Protection with OracleDBMSAssert
* Bulk Copy Boolean Data Type Support
* Password-Protected Wallet (PKCS#12) Support
* Password-Protected Wallet (PKCS#12) and Auto-Login Wallet (SSO) Support in Secure External Password Store (SEPS)
* Automatic Connection Recovery

## Bug Fixes since Oracle.ManagedDataAccess 23.7.0
* Bug 37753231 - FLEX DENSE VECTOR COLUMNS HAVE INCONSISTENT BEHAVIOR IN ORACLEDATAREADER.GETFIELDTYPE(), ORACLEDATAREADER.GETVALUE(), AND ORACLEDATAADAPTER.FILL()
* Bug 37705687 - WHEN ORACLEAQQUEUE.LISTEN() TIMES OUT, IT SHOULD RETURN NULL, RATHER THAN AN EXCEPTION THROWN FOR ORA-25254.
* Bug 37571978 - OPTIMIZE ORACLEDECIMAL.TOSTRING() AND ORACLEDATAREADER.GETSTRING() FOR NUMBER COLUMNS : HIGHER THROUGHPUT AND LOWER MEMORY USAGE
* Bug 37563784 - OPTIMIZE TOSTRING() METHOD FOR ORACLEDATE : HIGHER THROUGHPUT AND LOWER MEMORY USAGE
* Bug 37525372 - SYSTEM.ARGUMENTOUTOFRANGEEXCEPTION : INDEX WAS OUT OF RANGE, IS OBSERVED WHEN CLOB COLUMNS ARE IN THE RESULT SET AND FETCHSIZE IS SET
* Bug 37517481 - PERFORMANCE ISSUE WHEN ONLY NULLS ARE IN THE RESULT SET
* Bug 37495128 - ORA-50232: NETWORK TRANSPORT: TCP TRANSPORT ADDRESS CONNECT FAILURE DUE TO CACHED, STALE IP ADDRESS
* Bug 37490193 - ADD ORACLEBULKCOPYOPTIONS.ENFORCEINDEXCHECKS ENUMERATION VALUE TO ENABLE/DISABLE INDEX CHECKS DURING BULKCOPY
* Bug 37365816 - SUPPRESSGETDECIMALINVALIDCASTEXCEPTION WITH UDT NUMERIC PROPERTIES GENERATE ARITHMETIC OPERATION RESULTED IN AN OVERFLOW ERROR
* Bug 37160309 - TTC ERROR IS ENCOUNTERED WHEN OPENTELEMETRY ENABLESQLIDTRACING IS ENABLED AND COMMAND EXECUTION RETURNS REF CURSOR
* Bug 36759038 - APOSTROPHES IN CONNECT DESCRIPTOR USER VARIABLE CAUSE ORA-00303: SYNTAX ERROR IN NAME-VALUE STRING 

## Installation Changes
The following app/web.config entries are added when installing the managed ODP.NET NuGet package to your application:

1) Configuration Section Handler

A configuration section handler entry is added to the app/web.config to enable applications to add an <oracle.manageddataaccess.client> 
section for ODP.NET, Managed Driver-specific configuration.

Note: For a web app, if the same config section handler for "oracle.manageddataaccess.client" also exists in machine.config but the "Version" attribute values are different, an error message "There is a duplicate 'oracle.manageddataaccess.client' section defined." may be observed at runtime. To resolve the error, remove the "oracle.manageddataaccess.client" config section handler entry in the machine.config. If other applications on the machine depend on this machine.config entry, move the config section handler entry to each application's web.config file.

2) DbProviderFactories

The DbProviderFactories entry is added for applications that use DbProviderFactories and DbProviderFactory classes. Any DbProviderFactories entry for "Oracle.ManagedDataAccess.Client" in the machine.config will be ignored. 

3) Dependent Assembly

The dependent assembly entry is created to ignore policy DLLs for Oracle.ManagedDataAccess.dll. It directs the app to always use the Oracle.ManagedDataAccess.dll version that is specified by the "newVersion" attribute in the "bindingRedirect" element. The "newVersion" attribute corresponds to the Oracle.ManagedDataAccess.dll version which came with the NuGet package.

4) Data Sources

The data sources entry is added to provide a template on how a data source can be configured in the app/web.config. 
Simply rename the sample data source to an alias of your choosing; modify the PROTOCOL, HOST, PORT, SERVICE_NAME as required; 
and un-comment the "dataSource" element. Once that is done, the alias can be used as the "data source" attribute in 
your ODP.NET connection string.


 Copyright (c) 2024, 2025, Oracle and/or its affiliates.
