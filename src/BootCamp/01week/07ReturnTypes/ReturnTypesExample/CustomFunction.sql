CREATE FUNCTION [dbo].[FAyAd]
(
	@Ay TINYINT
)
RETURNS NVARCHAR(10)
AS
BEGIN
	RETURN	CASE @Ay
				WHEN 1 THEN 'Ocak'
				WHEN 2 THEN 'Şubat'
				WHEN 3 THEN 'Mart'
				WHEN 4 THEN 'Nisan'
				WHEN 5 THEN 'Mayıs'
				WHEN 6 THEN 'Haziran'
				WHEN 7 THEN 'Temmuz'
				WHEN 8 THEN 'Ağustos'
				WHEN 9 THEN 'Eylül'
				WHEN 10 THEN 'Ekim'
				WHEN 11 THEN 'Kasım'
				WHEN 12 THEN 'Aralık'
			END
END
