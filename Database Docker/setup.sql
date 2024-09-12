/*

Enter custom T-SQL here that would run after SQL Server has started up. 

*/
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'AcmePrizeDraw') 
BEGIN
    CREATE DATABASE AcmePrizeDraw;
END;
GO

USE AcmePrizeDraw;
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='SerialNumbers' and xtype='U')
BEGIN
    CREATE TABLE SerialNumbers (
        SerialNumber varchar(255) NOT NULL PRIMARY KEY
    );
    INSERT INTO SerialNumbers VALUES('KHFv64w2');
    INSERT INTO SerialNumbers VALUES('4qMzsUuh');
    INSERT INTO SerialNumbers VALUES('eFFwiIR3');
    INSERT INTO SerialNumbers VALUES('ypEoFA9a');
    INSERT INTO SerialNumbers VALUES('G4RF2Iny');
    INSERT INTO SerialNumbers VALUES('lCRMdQ1h');
    INSERT INTO SerialNumbers VALUES('j8h0Yq1E');
    INSERT INTO SerialNumbers VALUES('bhy2CtKj');
    INSERT INTO SerialNumbers VALUES('3mLbTfYB');
    INSERT INTO SerialNumbers VALUES('OERzDGR5');
    INSERT INTO SerialNumbers VALUES('G8Fvehcv');
    INSERT INTO SerialNumbers VALUES('Sj8F23rZ');
    INSERT INTO SerialNumbers VALUES('51INC6pP');
    INSERT INTO SerialNumbers VALUES('UUBg13lu');
    INSERT INTO SerialNumbers VALUES('o9QuF8yo');
    INSERT INTO SerialNumbers VALUES('0uNk1vZp');
    INSERT INTO SerialNumbers VALUES('orRZvlXN');
    INSERT INTO SerialNumbers VALUES('lSJuLTUJ');
    INSERT INTO SerialNumbers VALUES('ymCoIgpJ');
    INSERT INTO SerialNumbers VALUES('cvZtQU7e');
    INSERT INTO SerialNumbers VALUES('vm8YqHL8');
    INSERT INTO SerialNumbers VALUES('qUQNxuJU');
    INSERT INTO SerialNumbers VALUES('STUC0gN5');
    INSERT INTO SerialNumbers VALUES('2GpFnDH4');
    INSERT INTO SerialNumbers VALUES('NB54i4NT');
    INSERT INTO SerialNumbers VALUES('7cx2dK0N');
    INSERT INTO SerialNumbers VALUES('cGT6qzX6');
    INSERT INTO SerialNumbers VALUES('QQR7iTon');
    INSERT INTO SerialNumbers VALUES('kqtGFBHw');
    INSERT INTO SerialNumbers VALUES('1RPXB3wo');
    INSERT INTO SerialNumbers VALUES('JLc95CMp');
    INSERT INTO SerialNumbers VALUES('rZZ5NziC');
    INSERT INTO SerialNumbers VALUES('eWZgYSht');
    INSERT INTO SerialNumbers VALUES('G9AVeFr5');
    INSERT INTO SerialNumbers VALUES('QPZlKRqQ');
    INSERT INTO SerialNumbers VALUES('q3ZEiHP7');
    INSERT INTO SerialNumbers VALUES('eyWUZ5nn');
    INSERT INTO SerialNumbers VALUES('ZuX8KAzl');
    INSERT INTO SerialNumbers VALUES('psNzvru9');
    INSERT INTO SerialNumbers VALUES('kFe9PJX1');
    INSERT INTO SerialNumbers VALUES('sxeWbwrK');
    INSERT INTO SerialNumbers VALUES('WQBqQYOY');
    INSERT INTO SerialNumbers VALUES('MNnhLCGT');
    INSERT INTO SerialNumbers VALUES('Ja9HTEJD');
    INSERT INTO SerialNumbers VALUES('GvWZx7G9');
    INSERT INTO SerialNumbers VALUES('caiAP35G');
    INSERT INTO SerialNumbers VALUES('lFO82VT0');
    INSERT INTO SerialNumbers VALUES('s94VYgmT');
    INSERT INTO SerialNumbers VALUES('Wh7udDbu');
    INSERT INTO SerialNumbers VALUES('YF11kHXX');
    INSERT INTO SerialNumbers VALUES('pxFHgR2s');
    INSERT INTO SerialNumbers VALUES('iSpMuoU8');
    INSERT INTO SerialNumbers VALUES('gaQa9eME');
    INSERT INTO SerialNumbers VALUES('ML3GKeFe');
    INSERT INTO SerialNumbers VALUES('VnCFRUyU');
    INSERT INTO SerialNumbers VALUES('6lM7wTn9');
    INSERT INTO SerialNumbers VALUES('MaBIw3Ei');
    INSERT INTO SerialNumbers VALUES('qGUsWXRx');
    INSERT INTO SerialNumbers VALUES('imiOzujT');
    INSERT INTO SerialNumbers VALUES('HjtcZXrQ');
    INSERT INTO SerialNumbers VALUES('UdVTry0w');
    INSERT INTO SerialNumbers VALUES('DABYzyy8');
    INSERT INTO SerialNumbers VALUES('JJZMWjck');
    INSERT INTO SerialNumbers VALUES('ejPCXpeq');
    INSERT INTO SerialNumbers VALUES('v6F4sY6x');
    INSERT INTO SerialNumbers VALUES('4mhmWvSH');
    INSERT INTO SerialNumbers VALUES('cEZQeXuN');
    INSERT INTO SerialNumbers VALUES('6RwwTkU7');
    INSERT INTO SerialNumbers VALUES('LEuHxFLE');
    INSERT INTO SerialNumbers VALUES('zF7MN0xR');
    INSERT INTO SerialNumbers VALUES('PFi8kDai');
    INSERT INTO SerialNumbers VALUES('eQYvYmym');
    INSERT INTO SerialNumbers VALUES('H9UDXwWu');
    INSERT INTO SerialNumbers VALUES('mgKcd20J');
    INSERT INTO SerialNumbers VALUES('vvwS6ZsW');
    INSERT INTO SerialNumbers VALUES('oxUNvRRr');
    INSERT INTO SerialNumbers VALUES('WudflzqN');
    INSERT INTO SerialNumbers VALUES('yFiMfwQ1');
    INSERT INTO SerialNumbers VALUES('91lf5o2M');
    INSERT INTO SerialNumbers VALUES('oVY7J4Hm');
    INSERT INTO SerialNumbers VALUES('63LuKgE1');
    INSERT INTO SerialNumbers VALUES('OYhbOmaM');
    INSERT INTO SerialNumbers VALUES('XL6oYs4G');
    INSERT INTO SerialNumbers VALUES('Hhhtr9eA');
    INSERT INTO SerialNumbers VALUES('OixLo6kI');
    INSERT INTO SerialNumbers VALUES('vF9s9GTj');
    INSERT INTO SerialNumbers VALUES('uM0FndbL');
    INSERT INTO SerialNumbers VALUES('8ahJKHlc');
    INSERT INTO SerialNumbers VALUES('tWyEVmqg');
    INSERT INTO SerialNumbers VALUES('bJNr5hl0');
    INSERT INTO SerialNumbers VALUES('ovUpTTA6');
    INSERT INTO SerialNumbers VALUES('JwPCtrEa');
    INSERT INTO SerialNumbers VALUES('Td3icBcS');
    INSERT INTO SerialNumbers VALUES('b0d5TJYn');
    INSERT INTO SerialNumbers VALUES('ZYHK8fDD');
    INSERT INTO SerialNumbers VALUES('RErDApLs');
    INSERT INTO SerialNumbers VALUES('D5qMb9zF');
    INSERT INTO SerialNumbers VALUES('dL3UBSB7');
    INSERT INTO SerialNumbers VALUES('udgK8SRV');
    INSERT INTO SerialNumbers VALUES('pe3DBSw4');
END;
GO


IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Submissions' and xtype='U')
BEGIN
    CREATE TABLE Submissions (
        SubmissionId int IDENTITY(1,1) PRIMARY KEY,
        FirstName varchar(255) NOT NULL,
        LastName varchar(255) NOT NULL,
        Email varchar(255) NOT NULL,
        SerialNumber varchar(255) NOT NULL FOREIGN KEY REFERENCES SerialNumbers(SerialNumber)
    );
END;
GO

