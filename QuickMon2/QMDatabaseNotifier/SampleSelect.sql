SELECT TOP 100
	  [InsertDate],
	  [AlertLevel],
	  Category, PreviousState, CurrentState,
	  replace(Details, char(13) + CHAR(10) , '->') as 'Details'
FROM 
	vAlertMessages
order by 
	InsertDate desc