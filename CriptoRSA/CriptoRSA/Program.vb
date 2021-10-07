Imports System
Imports System.Numerics
Imports System.Text

Module Program


    Sub Main(args As String())
        Dim listaPalavra As New List(Of Char)
        Dim palavra As String = "daniel"
        palavra = palavra.ToLower

        For Each letras In palavra
            listaPalavra.Add(letras)
        Next

        Dim FraseCriptografadaRSA = CriptografarRSA(listaPalavra)
        Console.WriteLine($"A frase criptografada é igual a : {FraseCriptografadaRSA}")

        Dim fraseDescriptografadaRSA = Descriptografar(FraseCriptografadaRSA)
        Console.WriteLine($"A frase descriptorafada é igual a : {fraseDescriptografadaRSA}")

        Dim FrasecriptografadaMaoUnica = CriptoMaoUnica(listaPalavra)
        Console.WriteLine($"A frase criptografada mão unica é igual a : {FrasecriptografadaMaoUnica}")

    End Sub

    Private Function Porcentagem(Porcem As Integer, TamanhoHexDaCripto As Integer) As Integer

        Dim percentual As Integer
        percentual = CInt((Porcem * TamanhoHexDaCripto) / 100)

        Return percentual

    End Function

    Private Function Pow(numero As Integer, expoente As Integer) As BigInteger

        Dim numeroElevado As BigInteger = 0
        If expoente = 0 Then
            Return 1
        End If

        numeroElevado = Pow(numero, expoente - 1) * numero

        Return numeroElevado

    End Function

    Private Function CriptografarRSA(listaPalavra As List(Of Char)) As String

        Dim e As Integer = 13
        Dim Multiplicacaoprimos As Integer = 697
        Dim index = 0
        Dim criptografado As String = ""

        While index <= listaPalavra.Count - 1
            Dim numeroNaAsc = Asc(listaPalavra(index))

            criptografado += ((Pow(numeroNaAsc, e)) Mod Multiplicacaoprimos).ToString
            index += 1
        End While

        Return Ofuscar(criptografado)

    End Function

    Private Function Descriptografar(criptografado As String) As String

        criptografado = Desofuscar(criptografado)

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

    Private Function Desofuscar(Ofuscado As String) As String

        Dim desofuscadoListada As New List(Of Char)
        Dim index As String = 0

        Dim dictHexMeudesofuscar As New Dictionary(Of Char, Char)
        dictHexMeudesofuscar.Add("A", "0")
        dictHexMeudesofuscar.Add("3", "1")
        dictHexMeudesofuscar.Add("Z", "2")
        dictHexMeudesofuscar.Add("Y", "3")
        dictHexMeudesofuscar.Add("9", "4")
        dictHexMeudesofuscar.Add("B", "5")
        dictHexMeudesofuscar.Add("X", "6")
        dictHexMeudesofuscar.Add("*", "7")
        dictHexMeudesofuscar.Add(".", "8")
        dictHexMeudesofuscar.Add("?", "9")

        For Each letra In Ofuscado
            desofuscadoListada.Add(letra)
        Next

        If desofuscadoListada.Count <= 4 Then
            Dim temp = desofuscadoListada(0)
            desofuscadoListada(0) = desofuscadoListada(desofuscadoListada.Count - 1)
            desofuscadoListada(desofuscadoListada.Count - 1) = temp
        End If

        If desofuscadoListada.Count > 4 Then
            Dim temp = desofuscadoListada(Porcentagem(10, desofuscadoListada.Count))
            desofuscadoListada(Porcentagem(10, desofuscadoListada.Count)) = desofuscadoListada(Porcentagem(33, desofuscadoListada.Count))
            desofuscadoListada(Porcentagem(33, desofuscadoListada.Count)) = temp

            Dim temp1 = desofuscadoListada(Porcentagem(50, desofuscadoListada.Count))
            desofuscadoListada(Porcentagem(50, desofuscadoListada.Count)) = desofuscadoListada(Porcentagem(63, desofuscadoListada.Count))
            desofuscadoListada(Porcentagem(63, desofuscadoListada.Count)) = temp1
        End If

        While index <= desofuscadoListada.Count - 1
            desofuscadoListada(index) = dictHexMeudesofuscar(desofuscadoListada(index))
            index += 1
        End While

        Return desofuscadoListada.ToArray

    End Function

    Private Function Ofuscar(criptografia As String) As String

        Dim CriptoListada As New List(Of Char)
        Dim index As Integer = 0

        Dim dictHexMeu As New Dictionary(Of Char, Char)
        dictHexMeu.Add("0", "A")
        dictHexMeu.Add("1", "3")
        dictHexMeu.Add("2", "Z")
        dictHexMeu.Add("3", "Y")
        dictHexMeu.Add("4", "9")
        dictHexMeu.Add("5", "B")
        dictHexMeu.Add("6", "X")
        dictHexMeu.Add("7", "*")
        dictHexMeu.Add("8", ".")
        dictHexMeu.Add("9", "?")

        For Each numero In criptografia
            CriptoListada.Add(numero)
        Next

        While index <= CriptoListada.Count - 1
            CriptoListada(index) = dictHexMeu(CriptoListada(index))
            index += 1
        End While

        If CriptoListada.Count <= 4 Then
            Dim temp = CriptoListada(0)
            CriptoListada(0) = CriptoListada(CriptoListada.Count - 1)
            CriptoListada(CriptoListada.Count - 1) = temp
        End If

        If CriptoListada.Count > 4 Then
            Dim temp = CriptoListada(Porcentagem(10, CriptoListada.Count))
            CriptoListada(Porcentagem(10, CriptoListada.Count)) = CriptoListada(Porcentagem(33, CriptoListada.Count))
            CriptoListada(Porcentagem(33, CriptoListada.Count)) = temp

            Dim temp1 = CriptoListada(Porcentagem(50, CriptoListada.Count))
            CriptoListada(Porcentagem(50, CriptoListada.Count)) = CriptoListada(Porcentagem(63, CriptoListada.Count))
            CriptoListada(Porcentagem(63, CriptoListada.Count)) = temp1
        End If

        Return CriptoListada.ToArray


    End Function

    Private Function CriptoMaoUnica(PalavraListada As List(Of Char)) As String

        Dim e As Integer = 14
        Dim Multiplicacaoprimos As Integer = 640
        Dim index = 0
        Dim criptografado As String = ""

        While index <= PalavraListada.Count - 1
            Dim numeroNaAsc = Asc(PalavraListada(index))

            criptografado += ((Pow(numeroNaAsc, e)) Mod Multiplicacaoprimos).ToString
            index += 1
        End While

        Return Ofuscar(criptografado)

    End Function

End Module
