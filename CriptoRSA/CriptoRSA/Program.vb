Imports System

Module Program
    'numeros primos pré determinados coloque seus numeros primos
    Property NumeroP As Integer = 17
    Property NumeroQ As Integer = 41
    'numero primo aleatório que seja menor que phin e maior que 1 e que seja primo entre si
    Property e As Integer = 13
    ' chave privada foi encontrada apartir do algoritmo d*e MOD phiN = 1
    Property d As Integer = 197
    Property MultplicacaoPrimos = NumeroP * NumeroQ
    Property TotieneEulerFunction = (NumeroP - 1) * (NumeroQ - 1)

    Sub Main(args As String())
        Dim listaPalavra As New List(Of Char)
        Dim palavra = "daniel"
        palavra = palavra.ToLower
        For Each letra In palavra
            listaPalavra.Add(letra)
        Next

        Dim FraseCriptografadaRSA = CriptografarRSA(listaPalavra)
        Console.WriteLine($"A frase criptografada é igual a : {FraseCriptografadaRSA}")

    End Sub

    Private Function CriptografarRSA(listaPalavra As List(Of Char))
        Dim index = 0
        Dim criptografado As String = ""

        While index <= listaPalavra.Count - 1
            criptografado += (((Asc(listaPalavra(index))) ^ e) Mod MultplicacaoPrimos).ToString
            index += 1
        End While

        Return criptografado
    End Function

End Module
