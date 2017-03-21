        ' Generate the design-time markup.
        Public Overrides Function GetDesignTimeHtml() As String

            ' Make the control more visible in the designer.  If the border 
            ' style is None or NotSet, change the border to a blue dashed line. 
            Dim myLoginStatusCtl As MyLoginStatus = _
                CType(ViewControl, MyLoginStatus)
            Dim markup As String = Nothing

            ' Check if the border style should be changed.
            If (myLoginStatusCtl.BorderStyle = BorderStyle.NotSet Or _
                myLoginStatusCtl.BorderStyle = BorderStyle.None) Then

                Dim oldBorderStyle As BorderStyle = myLoginStatusCtl.BorderStyle
                Dim oldBorderColor As Color = myLoginStatusCtl.BorderColor

                ' Set the design time properties and catch any exceptions.
                Try
                    myLoginStatusCtl.BorderStyle = BorderStyle.Dashed
                    myLoginStatusCtl.BorderColor = Color.Blue

                    ' Call the base method to generate the markup.
                    markup = MyBase.GetDesignTimeHtml()

                Catch ex As Exception
                    markup = GetErrorDesignTimeHtml(ex)

                Finally
                    ' It is not necessary to restore the border properties 
                    ' to their original values because the ViewControl 
                    ' was used to reference the associated control and the 
                    ' UsePreviewControl was not overridden.  

                    ' myLoginCtl.BorderStyle = oldBorderStyle
                    ' myLoginCtl.BorderColor = oldBorderColor
                End Try

            Else
                ' Call the base method to generate the markup.
                markup = MyBase.GetDesignTimeHtml()
            End If

            Return markup

        End Function ' GetDesignTimeHtml