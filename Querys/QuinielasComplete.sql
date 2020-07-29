SELECT 
	Q.idQuiniela, 
	Q.QuinielaNo, 
	Q.Active, 
	QD.idSport, 
	S.SportName, 
	S.SportNameShort, 
	QD.idLiga, 
	L.LigaName, 
	L.LigaNameShort,
	L.LigaImgURL, 
	QD.idTorneo, 
	T.TorneoName,
	T.TorneoNameShort, 
	QD.idJornada, 
	J.JornadaName, 
	J.JornadaNameShort 
FROM Quinielas AS Q 
INNER JOIN QuinielasDetalle AS QD 
ON Q.idQuiniela = QD.idQuiniela 
INNER JOIN Sports AS S
ON QD.idSport = S.idSport 
INNER JOIN Ligas AS L
ON QD.idLiga = L.idLiga 
INNER JOIN Torneos AS T 
ON QD.idTorneo = T.idTorneo 
INNER JOIN Jornadas AS J
ON QD.idJornada = J.idJornada 
WHERE Q.idStatus = 4 AND Q.Active = 1 
AND QD.idSport = @idSport AND QD.idTorneo = @idTorneo


Select * from Quinielasdetalle 
Select * from Ligas
Select * from Torneos
Select * from Jornadas
Select * from Sports
Select * from Partidos
Select * from Equipos

idSport	SportName	Active	idUserAdd	DateAdd
1	Futbol	1	1	2020-07-16 00:00:00.000
truncate table Torneos

INSERT INTO Sports
select 'Futbol','FUT', 1,1,GETDATE()

idLiga	LigaName	LigaNameShort	LigaImgURL	Active	idCountry
1	Liga Mx	MX	/Images/Ligas/LigaMx.png	1	1

Select * from StatusProcess 