﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TP.Lecture;

namespace TP.Lecture.UnitTest
{
  [TestClass]
  public class StructUnitTest
  {
    private static void CoOrdsNoChange(BasicTypesStruct.CoOrdsStruct coOrds)
    {
      Random _rndm = new Random(DateTime.Now.Millisecond);
      coOrds.x = _rndm.Next();
      coOrds.y = _rndm.Next();
    }
    private static void CoOrdsChange(ref BasicTypesStruct.CoOrdsStruct coOrds)
    {
      Random _rndm = new Random(DateTime.Now.Millisecond);
      coOrds.x = _rndm.Next();
      coOrds.y = _rndm.Next();
    }
    private static void CoOrdsChange(BasicTypesStruct.CoOrdsClass coOrds)
    {
      Random _rndm = new Random(DateTime.Now.Millisecond);
      coOrds.x = _rndm.Next();
      coOrds.y = _rndm.Next();
    }
    [TestMethod]
    public void StructTestMethod()
    {
      //value type modification 
      BasicTypesStruct.CoOrdsStruct _bts1 = BasicTypesStruct.GetCoOrdsStruct();
      BasicTypesStruct.CoOrdsStruct _bts2 = BasicTypesStruct.GetCoOrdsStruct();
      CoOrdsNoChange(_bts1);
      try
      {
        Assert.AreSame(_bts1, _bts2);
        Assert.Fail();
      }
      catch (AssertFailedException) { }
      Assert.AreEqual(_bts1, _bts2);
      Assert.IsTrue(_bts1.x == _bts2.x);
      Assert.IsTrue(_bts1.y == _bts2.y);
      //
      CoOrdsChange(ref _bts1);
      try
      {
        Assert.AreSame(_bts1, _bts2);
        Assert.Fail();
      }
      catch (AssertFailedException)
      {

      }
      Assert.AreNotEqual(_bts1, _bts2);
      Assert.IsTrue(_bts1.x != _bts2.x);
      Assert.IsTrue(_bts1.y != _bts2.y);

      //Reference type modification
      BasicTypesStruct.CoOrdsClass _btscoc1 = new BasicTypesStruct.CoOrdsClass(1, 2);
      BasicTypesStruct.CoOrdsClass _btscoc2 = new BasicTypesStruct.CoOrdsClass(1, 2);
      CoOrdsChange(_btscoc1);
      Assert.AreNotSame(_btscoc1, _btscoc2);
      Assert.AreNotEqual(_btscoc1, _btscoc2);
      Assert.IsTrue(_btscoc1.x != _btscoc2.x);
      Assert.IsTrue(_btscoc1.y != _btscoc2.y);

    }
  }
  [TestClass]
  public class InterfaceTestClass
  {
    private const int c_OkIndex = 1;
    private const int c_WrongIndex = 25;
    [TestMethod]
    public void InterfaceTestMethod()
    {
      InterfaceExample _ie = new InterfaceExample();
      double _val = _ie[c_OkIndex];
      _ie[1] = new Random().NextDouble();
      Assert.AreNotEqual(_val, _ie[c_OkIndex]);
    }
    [TestMethod]
    public void InteraceCountTestMethod()
    {

      InterfaceExample _ie = new InterfaceExample();
      int _length = 0;
      foreach (double _item in _ie)
        _length++;
      Assert.AreEqual(_length, _ie.Count);

    }
    [TestMethod]
    [Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException(typeof(IndexOutOfRangeException))]
    public void InterfaceExceptionTestMethod()
    {

      InterfaceExample _ie = new InterfaceExample();
      double _val = _ie[c_WrongIndex];

    }
  }

  [TestClass]
  public class FileTestClass
  {
    [TestMethod]
    public void FileTestMethod()
    {
      string _fileName = "TestFileName.txt";
      FileExample _fileWrapper = new FileExample();
      _fileWrapper.CreateTextFile(_fileName);
      using (StreamReader _stream = File.OpenText(_fileName))
      {
        string _content = _stream.ReadToEnd();
        Assert.AreEqual(_content, _fileWrapper.FileContent);
      }
    }

  }
}
