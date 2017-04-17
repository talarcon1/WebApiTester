

Imports System.Net
Imports System.IO
Imports System.Text



Module Module1

    Sub Main()
        PostProduct()
        GetProduct()
    End Sub

    Public Function GetProduct() ',Optional ByVal ZipCode As String = "", Optional ByVal storeNumber As String = "", Optional ByVal associateId As String = "", Optional ByVal storeId As String = "") As Short
        Dim sSearch As String = ""
        Dim idSearch As Boolean
        Dim lresult As Short
        Dim WebReq As HttpWebRequest
        Dim WebResp As HttpWebResponse
        Dim respStream As Stream
        Dim sr As StreamReader
        Dim CallUrl As String
        Try


            CallUrl = "http://localhost:4166/api/products"

            WebReq = HttpWebRequest.Create(callURL)
            WebReq.Method = "GET"
            ' WebReq.Headers.Add("Authorization", "OAuth " & oAuth.Token.AccessToken)
            WebReq.Headers.Add("Accept-Language", "en-US")
            '  WebReq.Headers.Add("Program-Code", "GNCREWARDS")
            WebReq.ContentType = "application/json"
            'WebReq.Timeout = TimeoutSeconds * 1000

            WebResp = WebReq.GetResponse

            respStream = WebResp.GetResponseStream
            sr = New StreamReader(respStream)
            Dim json As String = sr.ReadToEnd

            '//@TA NOTE: non-fuzzy search(card or prof id) will fail and will return not_found after exception
            '// a fuzzy search (phone or email) will be caught when deserializing and return not_found if deserialization fails
            lresult = 0
            Console.WriteLine(json)
            Console.ReadLine()
            'If idSearch Then


            '    cust = AjaxPro.JavaScriptDeserializer.DeserializeFromJson(json, GetType(EpsilonCustomer))





        Catch ex As Exception
            Console.WriteLine("exception hit: " & ex.Message)
            Console.ReadLine()


        Finally
            'searchCount = 0
            If Not sr Is Nothing Then
                sr.Close()
            End If
            If Not respStream Is Nothing Then
                respStream.Close()
            End If
            If Not WebResp Is Nothing Then
                WebResp.Close()
            End If
        End Try

        Return lresult
    End Function
    Public Function PostProduct() As Short

        Dim WebReq As HttpWebRequest
        Dim WebResp As WebResponse
        Dim respStream As Stream
        Dim reqStream As Stream
        Dim sr As StreamReader
        Dim jsonString As String
        Dim callURL
        Try

            'Dim testProd As New Product
            'testProd.Id

            jsonString = "Id=4&Name=Test Prod&Category=Test Cat&Price=5.99" 'AjaxPro.JavaScriptSerializer.Serialize(cust)

            callURL = "http://localhost:4166/api/products/"


            WebReq = HttpWebRequest.Create(callURL)
            WebReq.Method = "POST"

            WebReq.Headers.Add("Accept-Language", "en-US")
            WebReq.ContentType = "application/x-www-form-urlencoded"


            Dim jsonBytes = Encoding.UTF8.GetBytes(jsonString)
                reqStream = WebReq.GetRequestStream()

                reqStream.Write(jsonBytes, 0, jsonBytes.Length)
                reqStream.Close()

                WebResp = WebReq.GetResponse
                respStream = WebResp.GetResponseStream
                sr = New StreamReader(respStream)
            Dim json As String = sr.ReadToEnd

            Dim test = 1








        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
            Console.ReadLine()
        Finally
            If Not reqStream Is Nothing Then
                reqStream.Close()
            End If
            If Not sr Is Nothing Then
                sr.Close()
            End If
            If Not respStream Is Nothing Then
                respStream.Close()
            End If
            If Not WebResp Is Nothing Then
                WebResp.Close()
            End If
        End Try

        Return 0
    End Function

End Module
