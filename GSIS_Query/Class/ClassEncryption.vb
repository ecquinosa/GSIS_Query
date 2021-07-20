Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Public Class ClassEncryption

    Dim DesKey As String = ""

    Dim strFileToEncrypt As String
    Dim strFileToDecrypt As String
    Dim strOutputEncrypt As String
    Dim strOutputDecrypt As String
    Dim fsInput As System.IO.FileStream
    Dim fsOutput As System.IO.FileStream

    Public Sub New(ByVal TripleDesKey As String)
        DesKey = TripleDesKey
    End Sub

    ''' <summary>
    ''' Encrypts a text using TripleDES Encryption.
    ''' </summary>
    ''' <param name="strText">A Valid String Object.</param>
    ''' <returns>Encrypted Text</returns>
    ''' <remarks>Encryption Key is "baronpogi" without the quotes.</remarks>
    Public Function TripleDesEncryptText(ByVal strText As String) As String
        Return TripleDesEncrypt(strText, DesKey)
    End Function

    ''' <summary>
    ''' Decrypts a text using TripleDes Decryption.
    ''' </summary>
    ''' <param name="strText">A Valid String Object.</param>
    ''' <returns>Decrypted Text</returns>
    ''' <remarks>Decryption Key is "baronpogi" without the quotes.</remarks>
    Public Function TripleDesDecryptText(ByVal strText As String) As String
        Return TripleDesDecrypt(strText, DesKey)
    End Function

    ''' <summary>
    ''' Procedure for ecrypting text using TripleDes Encryption.
    ''' </summary>
    ''' <param name="strText">A Valid String Object.</param>
    ''' <param name="strEncrKey">A Valid Key for Encryption.</param>
    ''' <returns>Encrypted Text</returns>
    Private Function TripleDesEncrypt(ByVal strText As String, ByVal strEncrKey As String) As String

        Dim byKey() As Byte = {}
        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}

        Try
            byKey = System.Text.Encoding.UTF8.GetBytes(Left(strEncrKey, 8))

            Dim des As New DESCryptoServiceProvider()
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(strText)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())

        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    ''' <summary>
    ''' Procedure for decrypting text using TripleDes Dencryption.
    ''' </summary>
    ''' <param name="strText">A Valid String Object.</param>
    ''' <param name="sDecrKey">A Valid Key for Dencryption.</param>
    ''' <returns>Dencrypted Text</returns>
    Private Function TripleDesDecrypt(ByVal strText As String, ByVal sDecrKey As String) As String

        Dim byKey() As Byte = {}
        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Dim inputByteArray(strText.Length) As Byte

        Try
            byKey = System.Text.Encoding.UTF8.GetBytes(Left(sDecrKey, 8))
            Dim des As New DESCryptoServiceProvider()
            inputByteArray = Convert.FromBase64String(strText)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write)

            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8

            Return encoding.GetString(ms.ToArray())

        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    ''' <summary>
    ''' Encrypts a String using MD5 Encryption.
    ''' </summary>
    ''' <param name="StringToEncrypt">A Valid String Object.</param>
    ''' <returns>Encrypted Text.</returns>
    ''' <remarks>This code doesn't have a decryption procedure.</remarks>
    Public Function MD5Encrypt(ByVal StringToEncrypt As String) As String

        Dim md5 As MD5CryptoServiceProvider
        Dim bytValue() As Byte
        Dim bytHash() As Byte
        Dim strOutput As String = ""
        Dim i As Integer

        md5 = New MD5CryptoServiceProvider

        bytValue = System.Text.Encoding.UTF8.GetBytes(StringToEncrypt)

        bytHash = md5.ComputeHash(bytValue)
        md5.Clear()

        For i = 0 To bytHash.Length - 1
            strOutput &= bytHash(i).ToString("x").PadLeft(2, "0")
        Next

        MD5Encrypt = strOutput

    End Function

    ''' <summary>
    ''' Procedure for Encrypting and Decrypting a simple text by changing the characters into a special character.
    ''' </summary>
    ''' <param name="StringToEnDecrypt">A Valid String Object.</param>
    ''' <returns>Encrypted or Decrypted text.</returns>
    ''' <remarks>Returns a decrypted text when the parameter is encrypted and vice versa.</remarks>
    Public Function EnDeCrypt(ByVal StringToEnDecrypt As String) As String
        Dim strTempChar As String = ""
        Dim i As Integer
        For i = 1 To Len(StringToEnDecrypt)
            If Asc(Mid$(StringToEnDecrypt, i, 1)) < 128 Then
                strTempChar = Asc(Mid$(StringToEnDecrypt, i, 1)) + 128
            ElseIf Asc(Mid$(StringToEnDecrypt, i, 1)) > 128 Then
                strTempChar = Asc(Mid$(StringToEnDecrypt, i, 1)) - 128
            End If
            Mid$(StringToEnDecrypt, i, 1) = Chr(strTempChar)
        Next i
        EnDeCrypt = StringToEnDecrypt
    End Function

    Public Function HASH_SHA1(ByVal text As String) As String

        Dim sha As New SHA1Managed
        Dim buff() As Byte = System.Text.ASCIIEncoding.UTF8.GetBytes(text)
        Dim hash() As Byte = sha.ComputeHash(buff)

        Return Convert.ToBase64String(hash)

        'Dim SHA1 As New SHA1Managed
        'Dim hash() As Byte = SHA1.ComputeHash(System.Text.ASCIIEncoding.UTF8.GetBytes(text))
        'Dim signed_Hash(hash.Length - 1) As SByte
        'Dim tInt As Integer = 0
        'Dim b64 As New Org.BouncyCastle.Utilities.Encoders.Base64Encoder
        'Dim bc64 As Byte() = hash
        'Dim s As System.IO.Stream
        'b64.Encode(hash, 0, hash.Length, s)

        'For i As Integer = 0 To hash.Length - 1
        '    If CInt(hash(i)) > 127 Then
        '        tInt = hash(i) - 256
        '    Else
        '        tInt = hash(i)
        '    End If
        '    signed_Hash(i) = tInt
        'Next

        'Dim tStr As String = ""

        'For i As Integer = 0 To signed_Hash.Length - 1
        '    tStr += signed_Hash(i).ToString("X2").ToLower
        'Next

        'Dim util As New AllCardTech_UMID.AllCardTech_Util
        'Dim hash2(CInt(tStr.Length / 2) - 1) As Byte

        'util.HexStringToByteArray(tStr, hash2)

        'Dim t() As Byte = Convert.FromBase64String("yMPii+n4oCVpelyUM/4OiJW8hhg=")
        'Dim t2 As String = System.Text.ASCIIEncoding.UTF8.GetString(t)

        'Return Convert.ToBase64String(hash2)


        'Return "test"

        '        MessageDigest md = null;
        'try {
        '    md = MessageDigest.getInstance("SHA"); //step 2
        '} catch (NoSuchAlgorithmException e) {
        '    throw new Exception(e.getMessage());
        '}
        'try {
        '    md.update(plaintext.getBytes("UTF-8")); //step 3
        '} catch (UnsupportedEncodingException e) {
        '    throw new Exception(e.getMessage());
        '}

        'byte raw[] = md.digest(); //step 4
        'String hash = (new BASE64Encoder()).encode(raw); //step 5
        'return hash; //step 6

        '      string message = "abc";
        'SHA1 sha = new SHA1Managed();
        'ASCIIEncoding ae = new ASCIIEncoding();
        'byte[] data = ae.GetBytes(message);
        'byte[] digest = sha.ComputeHash(data);
        'Console.WriteLine(GetAsString(digest));
        'Console.ReadLine();


        'Dim TEST() As Byte = {34}

        'Dim sha As New SHA1Managed
        'Dim ae As New ASCIIEncoding
        'Dim data As Byte() = ae.GetBytes(text)
        'Dim digest As SByte() = sha.ComputeHash(data)
        'Dim bStr As String = GetAsString(digest)
        ''Dim bHex() As String = bStr.Split(" ")
        ''Dim tStr As String = ""
        ''Dim mustValue As String = "a9993e364706816aba3e25717850c26c9cd0d89d"
        'Dim JavaValue As String = "34 -22 28 100 -100 -126 -108 106 -90 -28 121 -31 -1 -45 33 -28 -93 24 -79 -80"

        ''For i As Integer = 0 To bHex.Length - 1
        ''    tStr += CInt(bHex(i)).ToString("X2")
        ''Next

        'MsgBox(bStr + vbNewLine + JavaValue)

        'Return Convert.ToBase64String(TEST)


    End Function

    Public Function GetAsString(ByVal bytes As Byte()) As String
        Dim s As New StringBuilder
        Dim length As Integer = bytes.Length
        For i As Integer = 0 To length - 1
            s.Append(CInt(bytes(i)))
            If Not i = length - 1 Then
                s.Append(" ")
            End If
        Next
        Return s.ToString
    End Function

End Class
