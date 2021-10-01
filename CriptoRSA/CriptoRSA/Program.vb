Imports System
Imports System.Numerics

Module Program


    Sub Main(args As String())
        Dim listaPalavra As New List(Of Char)
        Dim palavra = "daniel"
        palavra = palavra.ToLower

        For Each letras In palavra
            listaPalavra.Add(letras)
        Next

        Dim FraseCriptografadaRSA = CriptografarRSA(listaPalavra)
        Console.WriteLine($"A frase criptografada é igual a : {FraseCriptografadaRSA}")
        Dim fraseDescriptografadaRSA = Descriptografar(FraseCriptografadaRSA)
        Console.WriteLine(fraseDescriptografadaRSA)

    End Sub

    Private Function Pow(numero As Integer, expoente As Integer) As BigInteger

        Dim numeroElevado As BigInteger = 0
        If expoente = 0 Then
            Return 1
        End If

        numeroElevado = Pow(numero, expoente - 1) * numero

        Return numeroElevado

    End Function

    Private Function CriptografarRSA(listaPalavra As List(Of Char))
        Dim e As Integer = 13
        Dim Multiplicacaoprimos As Integer = 697
        Dim index = 0
        Dim criptografado As String = ""

        While index <= listaPalavra.Count - 1
            Dim numeroNaAsc = Asc(listaPalavra(index))

            criptografado += ((Pow(numeroNaAsc, e)) Mod Multiplicacaoprimos).ToString
            index += 1
        End While
        Return criptografado
    End Function

    Private Function Descriptografar(criptografado As String)
        Dim e As Integer = 197
        Dim Multiplicacaoprimos As Integer = 697
        Dim index = 0
        Dim indexfinal = index + 3
        Dim descriptografado As String = ""

        While index <= criptografado.Count - 1
            Dim numeroLetra = criptografado.Substring(index, 3)
            descriptografado += Chr(((Pow(numeroLetra, e)) Mod Multiplicacaoprimos))
            index += 3
        End While
        Return descriptografado

    End Function


End Module
