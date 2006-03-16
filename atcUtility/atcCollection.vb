Public Class atcCollection
  Inherits ArrayList

  Private pKeys As ArrayList = New ArrayList

  Public Sub New(ByVal ParamArray aValuesToAdd() As Object)
    MyBase.New()
    AddRange(aValuesToAdd)
  End Sub

  Public Property Keys() As ArrayList
    Get
      Return pKeys
    End Get
    Set(ByVal newValue As ArrayList)
      pKeys = newValue
    End Set
  End Property

  Public Shadows Function Add(ByVal Value As Object) As Integer
    Return Add(Value, Value)
  End Function
  Public Shadows Function Add(ByVal key As Object, ByVal value As Object) As Integer
    pKeys.Add(key)
    Return MyBase.Add(value)
  End Function

  Public Shadows Sub AddRange(ByVal c As System.Collections.ICollection)
    pKeys.AddRange(c)
    MyBase.AddRange(c)
  End Sub

  Public Shadows Property Capacity() As Integer
    Get
      Return MyBase.Capacity
    End Get
    Set(ByVal newValue As Integer)
      pKeys.Capacity = newValue
      MyBase.Capacity = newValue
    End Set
  End Property

  Public Shadows Sub Clear()
    pKeys.Clear()
    MyBase.Clear()
  End Sub

  Public Shadows Function Clone() As atcCollection
    Dim newClone As New atcCollection
    For index As Integer = 0 To MyBase.Count - 1
      newClone.Add(pKeys.Item(index), MyBase.Item(index))
    Next
    Return newClone
  End Function

  Public Shadows Sub Insert(ByVal index As Integer, ByVal value As Object)
    Insert(index, value, value)
  End Sub
  Public Shadows Sub Insert(ByVal index As Integer, ByVal key As Object, ByVal value As Object)
    pKeys.Insert(index, key)
    MyBase.Insert(index, value)
  End Sub

  Public Shadows Sub InsertRange(ByVal index As Integer, ByVal collValues As ICollection)
    InsertRange(index, collValues, collValues)
  End Sub
  Public Shadows Sub InsertRange(ByVal index As Integer, ByVal collKeys As ICollection, ByVal collValues As ICollection)
    pKeys.InsertRange(index, collKeys)
    MyBase.InsertRange(index, collValues)
  End Sub

  Public Shadows Sub Remove(ByVal value As Object)
    Try
      Dim index As Integer = MyBase.IndexOf(value)
      If index >= 0 Then RemoveAt(index)
    Catch e As Exception
    End Try
  End Sub

  Public Overridable Sub RemoveByKey(ByVal key As Object)
    Try
      Dim index As Integer = pKeys.IndexOf(key)
      If index >= 0 Then RemoveAt(index)
    Catch e As Exception
    End Try
  End Sub

  Public Shadows Sub RemoveAt(ByVal index As Integer)
    pKeys.RemoveAt(index)
    MyBase.RemoveAt(index)
  End Sub

  Public Shadows Sub RemoveRange(ByVal index As Integer, ByVal count As Integer)
    pKeys.RemoveRange(index, count)
    MyBase.RemoveRange(index, count)
  End Sub

  Public Shadows Sub Reverse()
    pKeys.Reverse()
    MyBase.Reverse()
  End Sub

  Public Shadows Sub Reverse(ByVal index As Integer, ByVal count As Integer)
    pKeys.Reverse(index, count)
    MyBase.Reverse(index, count)
  End Sub

  Public Shadows Sub SetRange(ByVal index As Integer, ByVal values As ICollection)
    SetRange(index, values, values)
  End Sub
  Public Shadows Sub SetRange(ByVal index As Integer, ByVal keys As ICollection, ByVal values As ICollection)
    pKeys.SetRange(index, keys)
    MyBase.SetRange(index, keys)
  End Sub

  Public Shadows Sub Sort()
    Sort(New Comparer(New System.Globalization.CultureInfo("")))
  End Sub

  Public Shadows Sub Sort(ByVal comparer As System.Collections.IComparer)
    Sort(0, MyBase.Count, comparer)
  End Sub

  Public Shadows Sub Sort(ByVal index As Integer, ByVal count As Integer, ByVal comparer As System.Collections.IComparer)
    Dim lNewKeys As ArrayList = New ArrayList(pKeys)
    Dim lNewValues As New ArrayList
    Dim lOldIndex As Integer
    lNewKeys.Sort(index, count, comparer)
    For Each lNewKey As Object In lNewKeys
      lOldIndex = pKeys.IndexOf(lNewKey)
      lNewValues.Add(MyBase.Item(lOldIndex))
      pKeys.Item(lOldIndex) = Nothing
    Next
    MyBase.Clear()
    MyBase.AddRange(lNewValues)
  End Sub

  Public Shadows Sub TrimToSize()
    pKeys.TrimToSize()
    MyBase.TrimToSize()
  End Sub

  'Exactly the same as Item. Added for clarity as a parallel to ItemByKey.
  Public Overridable Property ItemByIndex(ByVal index As Integer) As Object
    Get
      Return MyBase.Item(index)
    End Get
    Set(ByVal newValue As Object)
      MyBase.Item(index) = newValue
    End Set
  End Property

  Public Property ItemByKey(ByVal key As Object) As Object
    Get
      Dim index As Integer = IndexFromKey(key)
      If index >= 0 Then
        Return MyBase.Item(index)
      Else
        Return Nothing
      End If
    End Get
    Set(ByVal newValue As Object)
      Dim index As Integer = IndexFromKey(key)
      If index >= 0 Then
        MyBase.Item(index) = newValue
      Else
        Add(key, newValue)
      End If
    End Set
  End Property

  Public Function IndexFromKey(ByVal key As Object) As Integer
    Try
      Return pKeys.IndexOf(key)
    Catch e As Exception
      Return -1
    End Try
  End Function

  Public Sub ChangeTo(ByVal aNewItems As atcCollection)
    Clear()
    For index As Integer = 0 To aNewItems.Count - 1
      Add(aNewItems.Keys(index), aNewItems.ItemByIndex(index))
    Next
  End Sub

  Public Overrides Function ToString() As String
    Dim lCount As Integer = Me.Count
    Dim lString As String = "Collection "
    Select Case lCount
      Case 0 : lString &= "Empty"
      Case 1 : lString &= "of 1 value"
      Case Else
        lString &= "of " & lCount & " values"     
    End Select
    Dim i As Integer
    Dim lStop As Integer = lCount - 1
    If lStop > 9 Then lStop = 9
    For i = 0 To lStop
      Try
        lString &= vbCrLf & i & " key = " & Me.Keys.Item(i) & ", value = " & Me.ItemByIndex(i) & vbCrLf
      Catch
        'Skip listing unprintable keys/values
      End Try
    Next
    'If lStop < lCount - 1 Then
    '  i = lCount - 1
    '  lString &= "..." & vbCrLf
    '  lString &= vbCrLf & i & " "
    '  Try
    '    lString &= vbCrLf & i & " " & Me.Keys.Item(i) & " : " & Me.ItemByIndex(i) & vbCrLf
    '  Catch
    '  End Try
    'End If
    Return lString
  End Function
End Class
