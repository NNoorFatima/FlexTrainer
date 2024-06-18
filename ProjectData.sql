
create database ProjectData ; 
use ProjectData ; 

-- Member is keyword. 
select * from dbo.Temp_Member;
select * from dbo.Temp_owner;
select * from dbo.Temp_Gym;
select * from dbo.Temp_Trainer;

drop table temp_member


insert into temp_member values('22m-050','22g-001','Weight loss',3,'NONE','Approved','Ali','Ali123','Ali@gmail.com','2028-12-12','2012-10-12');
delete from temp_member where MemberID = '22m-050' ; 


--- member ka table need gym 
CREATE TABLE Members (
    MemberId nvarchar(50) PRIMARY KEY, 
    GymID nvarchar(50), 
    Fitness_Goal nvarchar(50), 
    Membership_Type int, 
    HealthCondition nvarchar(50), 
    ActiveStatus nvarchar(50), 
    UserName nvarchar(50), 
    Member_Password nvarchar(50), 
    Email nvarchar(50), 
    Reg_Date date, 
    Mem_StartDate date,
    FOREIGN KEY (GymID) REFERENCES Gym(GYMID)

);

-- gym ka table need admin , owner , 



-- owner needs no one 

create Table Owners (
OwnerID nvarchar (50) primary Key , 
UserName nvarchar(50), 
Owner_Password nvarchar(50), 
Email nvarchar(50), 
Status nvarchar (50)     

);

select * from dbo.Temp_owner;

insert into Owners values ('22o-1036' , 'Rabail Zahid' , 'rabail123' , 'rabail@gmail.com' , 'Approved'  ) ; 
insert into Owners values ('22o-1037' , 'Fasail Cheema' , 'faisal123' , 'faisal@gmail.com' , 'Approved'  ) ; 
insert into Owners values ('22o-1038' , 'Maryam Shabaz' , 'maryam123' , 'maryam@gmail.com' , 'Approved'  ) ; 

select * from Owners ;
select Owners.status from Owners where OwnerID = '22O-1036'; 

delete from Owners where OwnerID = '22O-1037'; 

delete from Owners where OwnerID = '22O-1036'; 
delete from Owners where OwnerID = '22O-1038'; 


-- admin ka table 
select * from temp_admin ; 


create Table Admins (
AdminID nvarchar (50) primary Key , 
UserName nvarchar(50), 
Admin_Password nvarchar(50), 
Email nvarchar(50), 
Reg_date date 

);

drop table Admins

select * from Admins ;

insert into Admins values ('22a-001',	'amna irum'	,'amna123',	'amnairaum@gmail.com'	,'2010-01-11' ) ; 

insert into Admins values ('22a-002',	'majid hussain'	,'majid123',	'majidhussain@gmail.com'	,'2010-02-11' ) ; 
insert into Admins values ('22a-003',	'usman awan','usman123',	'usmanawan@gmail.com'		,'2023-05-11' ) ; 
insert into Admins values ('22a-004',	'adnan tariq'	,'adnan123',	'adnantariq@gmail.com'	,'2023-06-11' ) ; 


delete from Admins where AdminId = '22a-001' ; 

delete from Admins where AdminId = '22a-002' ; 
delete from Admins where AdminId = '22a-003' ; 
delete from Admins where AdminId = '22a-004' ; 


select * from dbo.Temp_Gym;
--- gyms needs owner and admin 


create Table Gym (
GymID nvarchar (50) primary key , 
Location nvarchar (50) , 
Facilities nvarchar (50) ,
OwnerID nvarchar (50) , 
AdminID nvarchar (50) , 
ActiveStatus nvarchar (50)  
    CONSTRAINT FK_AdminId FOREIGN KEY (AdminId) REFERENCES Admins(AdminId) 
	ON DELETE SET DEFAULT,
    CONSTRAINT FK_OwnerId FOREIGN KEY (OwnerId) REFERENCES Owners(OwnerId) 
	ON DELETE SET DEFAULT
);


select * from [temp_Gym ] ;

------ cursor for gym 

DECLARE @GymID NVARCHAR(50)
DECLARE @Location NVARCHAR(50)
DECLARE @Facilities NVARCHAR(50)
DECLARE @OwnerID NVARCHAR(50)
DECLARE @AdminID NVARCHAR(50)
DECLARE @ActiveStatus NVARCHAR(50)

DECLARE GymCursor CURSOR FOR
SELECT GymID, Location, Facilities, OnwerID, AdminID, ActiveStatus
FROM temp_gym

OPEN GymCursor

FETCH NEXT FROM GymCursor INTO @GymID, @Location, @Facilities, @OwnerID, @AdminID, @ActiveStatus

WHILE @@FETCH_STATUS = 0
BEGIN
    INSERT INTO Gym (GymID, Location, Facilities, OwnerID, AdminID, ActiveStatus)
    VALUES (@GymID, @Location, @Facilities, @OwnerID, @AdminID, @ActiveStatus)

    FETCH NEXT FROM GymCursor INTO @GymID, @Location, @Facilities, @OwnerID, @AdminID, @ActiveStatus
END

CLOSE GymCursor
DEALLOCATE GymCursor



select * from Gym ;


EXEC sp_rename 'temp_GYM.ONWERID',  'OwnerID', 'COLUMN';


---------- transfering data from csv to Members Table
DECLARE @MemberId NVARCHAR(50)
DECLARE @GymID NVARCHAR(50)
DECLARE @Fitness_Goal NVARCHAR(50)
DECLARE @Membership_Type INT
DECLARE @HealthCondition NVARCHAR(50)
DECLARE @ActiveStatus NVARCHAR(50)
DECLARE @UserName NVARCHAR(50)
DECLARE @Member_Password NVARCHAR(50)
DECLARE @Email NVARCHAR(50)
DECLARE @Reg_Date DATE
DECLARE @Mem_StartDate DATE

DECLARE MemberCursor CURSOR FOR
SELECT MemberId, GymID, Fitness_Goal, Membership_Type, HealthCondition, ActiveStatus, UserName, Password, Email, Reg_Date, Mem_StartDate
FROM temp_member

OPEN MemberCursor

FETCH NEXT FROM MemberCursor INTO @MemberId, @GymID, @Fitness_Goal, @Membership_Type, @HealthCondition, @ActiveStatus, @UserName, @Member_Password, @Email, @Reg_Date, @Mem_StartDate

WHILE @@FETCH_STATUS = 0
BEGIN
    INSERT INTO Members (MemberId, GymID, Fitness_Goal, Membership_Type, HealthCondition, ActiveStatus, UserName, Member_Password, Email, Reg_Date, Mem_StartDate)
    VALUES (@MemberId, @GymID, @Fitness_Goal, @Membership_Type, @HealthCondition, @ActiveStatus, @UserName, @Member_Password, @Email, @Reg_Date, @Mem_StartDate)

    FETCH NEXT FROM MemberCursor INTO @MemberId, @GymID, @Fitness_Goal, @Membership_Type, @HealthCondition, @ActiveStatus, @UserName, @Member_Password, @Email, @Reg_Date, @Mem_StartDate
END

CLOSE MemberCursor
DEALLOCATE MemberCursor

select * from Members ; 
select * from GYM ;
select * from Owners ;


-----------------------------------------------


select * from dbo.Worksfor;
select * from Exercises ; 
select* from temp_workoutPlan ; 
select * from dbo.Temp_Workout_part_exercise;


select * from Members ; 


-- member interface : work out plan
-- chose from already present plans 
-- or select the exercises and make ur own plan. 

-- inut validaition , member exits 
select count (*) from Members 
where MemberID = '22m-101'  ; -- and Member_Password = 'sara123' ;

select count(*) from Members where MemberId = '22m-001' and Member_Password = 'sara123'; 


-- registration member with this eamil exits. 
select count (*) from Temp_Member 
where Email = 'noor@gmail.com' ; 






SELECT  tpw.PlanName , Duration_months as Duration , PlanDescription
FROM temp_workoutPlan tpw
JOIN dbo.Temp_Workout_part_exercise twpe ON tpw.PlanID = twpe.PlanID
JOIN Exercises e ON twpe.ExerciseID = e.ExerciseID
WHERE e.Sets <= 4 
AND e.Reps <= 6 
AND e.RestIntervals_minutes <= 3 
AND e.MuscleGroup = 'biceps and triceps'  ;

select GymID from Gym ; 


-- custom made 



----- MEAL TABLE 


create table Meals (
MealsID int primary key ,
Calories int ,
Fat int , 
Protien	int ,
Carb int , 
MealName nvarchar(150) , 
MealType nvarchar (150)

) ;


select * from Meals ;

drop table Meals ; 

create table Trainer (

TrainerID nvarchar (150) primary key	,
Username nvarchar (150)	,
Trainer_Password nvarchar (150)	, 
Email  nvarchar (150)	,
Reg_date date ,
Certification nvarchar (150),	
Specialization	nvarchar (150),
Experience int 

);

select * from Temp_trainer ;

DECLARE @TrainerID NVARCHAR(150);
DECLARE @Username NVARCHAR(150);
DECLARE @Trainer_Password NVARCHAR(150);
DECLARE @Email NVARCHAR(150);
DECLARE @Reg_date DATE;
DECLARE @Certification NVARCHAR(150);
DECLARE @Specialization NVARCHAR(150);
DECLARE @Experience INT;

DECLARE TrainerCursor CURSOR FOR
SELECT TrainerID, Username, Password, Email, Reg_date, Certification, Specialization, Experience
FROM temp_trainer;

OPEN TrainerCursor;

FETCH NEXT FROM TrainerCursor INTO @TrainerID, @Username, @Trainer_Password, @Email, @Reg_date, @Certification, @Specialization, @Experience;

WHILE @@FETCH_STATUS = 0
BEGIN
    INSERT INTO Trainer (TrainerID, Username, Trainer_Password, Email, Reg_date, Certification, Specialization, Experience)
    VALUES (@TrainerID, @Username, @Trainer_Password, @Email, @Reg_date, @Certification, @Specialization, @Experience);

    FETCH NEXT FROM TrainerCursor INTO @TrainerID, @Username, @Trainer_Password, @Email, @Reg_date, @Certification, @Specialization, @Experience;
END

CLOSE TrainerCursor;
DEALLOCATE TrainerCursor;


select * from Trainer ;

drop table Trainer ;




----  workout plan 


CREATE TABLE WorkOutPlan (
    PlanID INT PRIMARY KEY,
    CreationDate DATE,
    TrainerId NVARCHAR(150),
    PlanName NVARCHAR(MAX),
    Goal NVARCHAR(MAX),
    Duration INT,
    PlanDescription NVARCHAR(MAX),
    CONSTRAINT FK_TrainerId FOREIGN KEY (TrainerId) REFERENCES Trainer(TrainerId) 
	ON DELETE SET DEFAULT ON UPDATE CASCADE
);


select * from WorkOutPlan ; 



-- triner works in which GYM table 

create table Worksin (
TrainerID nvarchar (50),
GymID	nvarchar (50 ) , 
OwnerID nvarchar (50 )


) ; 

select * from Worksin ; 

--- F5 or ctrl +e to run query 


-- exercises table. 


create Table Exercises (

ExerciseID	int primary key ,
ExerciseName nvarchar (190) , 
MuscleGroup nvarchar (150),	
RestIntervals int ,	
Sets int , 
Reps int 

) ;

select * from Exercises ; 
drop table Exercises ;



-- machines table 

create Table Machine (

MachineID	int ,
MachineName nvarchar (100) , 
ExerciseID int 


);

select * from machine ;



-- feedback table 

create table Feedback (

FeedbackID int , 
MemberID nvarchar (50  )	, 
TrainerID nvarchar (100) , 
Rating	int ,  -- out of 5 

FeedbackDate date , 
Comments nvarchar (100)


) ;
