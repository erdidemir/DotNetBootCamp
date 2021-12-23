
SELECT 2147483647 / 2 AS Result1, 2147483649 / 2 AS Result2 ;  

DECLARE @Para DECIMAL(18,2) = 10.15

DECLARE @Day DATETIME = GETDATE();

SELECT @Day

SELECT YEAR(@Day)

DECLARE @TXT NVARCHAR(MAX) = ''

DECLARE @TBL TABLE(EndeksAd nvarchar(400), Yil INT, StrAy   NVARCHAR(MAX), Deger NVARCHAR(MAX))

DECLARE @EndeksAd nvarchar(400),
@YuzdeOran nvarchar(5) ,
@Deger  NVARCHAR(MAX),
@StrAy   NVARCHAR(MAX)


DECLARE @EndeksTuruId INT
DECLARE @Sayi INT 

DECLARE @Yil INT = YEAR(GETDATE())
DECLARE @Ay INT = 0

INSERT INTO @TBL
VALUES
( 'Aydınlatma Abone Grubu - AG Tek Terim - Tek Zamanlı',   '2021' ,   'Eylül' ,   '87,9793'  ),
( 'Aydınlatma Abone Grubu - AG Tek Terim - Çok Zamanlı',   '2021' ,   'Eylül' ,   '89,9793'  )


 DECLARE C CURSOR LOCAL FOR
 SELECT
	EndeksAd,
	Yil,
	StrAy,  
	Deger

FROM 
@TBL

	OPEN C

	FETCH NEXT FROM C
	INTO	@EndeksAd,
			@Yil,
			@StrAy,  
			@Deger

	WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		--SQL

		IF @StrAy = 'Ocak'
		BEGIN
			SET @Ay = 01

			--SELECT @Ay
		END

		IF @StrAy = 'Şubat'
		BEGIN
			SET @Ay = 02

			--SELECT @Ay
		END

		IF @StrAy = 'Mart'
		BEGIN
			SET @Ay = 03

			--SELECT @Ay
		END

		IF @StrAy = 'Nisan'
		BEGIN
			SET @Ay = 04

			--SELECT @Ay
		END

		IF @StrAy = 'Mayıs'
		BEGIN
			SET @Ay = 05

			--SELECT @Ay
		END

		IF @StrAy = 'Haziran'
		BEGIN
			SET @Ay = 06

			--SELECT @Ay
		END

		IF @StrAy = 'Temmuz'
		BEGIN
			SET @Ay = 07

			--SELECT @Ay
		END

		IF @StrAy = 'Ağustos'
		BEGIN
			SET @Ay = 08

			--SELECT @Ay
		END

		IF @StrAy = 'Eylül'
		BEGIN
			SET @Ay = 09

			--SELECT @Ay
		END

		IF @StrAy = 'Ekim'
		BEGIN
			SET @Ay = 10

			--SELECT @Ay
		END

		IF @StrAy = 'Kasım'
		BEGIN
			SET @Ay = 11

			--SELECT @Ay
		END

		IF @StrAy = 'Aralık'
		BEGIN
			SET @Ay = 12

			--SELECT @Ay
		END

		SELECT @EndeksTuruId = 10--test

		IF ISNULL(@EndeksTuruId,0)> 0
		BEGIN
			SELECT @Deger
		END
		ELSE
		BEGIN
			SELECT @EndeksAd
		END
		
		FETCH NEXT FROM C
		INTO @EndeksAd,
			 @Yil,
			 @StrAy,  
			 @Deger

	END

	CLOSE C
	DEALLOCATE C


	