using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;
using Unity.Netcode;
using UnityEditor;
using NUnit.Framework.Constraints;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Assert = NUnit.Framework.Assert;

public class CombinationTests : InputTestFixture
{
    public GameObject comboPuzzle = Resources.Load<GameObject>("CombinationPuzzle");
    public GameObject characterInstance;
/*
    SimonButton red = new SimonButton();
    SimonButton blue = new SimonButton();
    SimonButton green = new SimonButton();
    SimonButton yellow = new SimonButton();
*/
    public override void Setup()
    {
        SceneManager.LoadScene("Scenes/Test");
        base.Setup();

        characterInstance = GameObject.Instantiate(comboPuzzle, Vector3.zero, Quaternion.identity);
    }

    [Test]
    public void ComboSpawnTest()
    {
        NUnit.Framework.Assert.IsTrue(comboPuzzle.activeSelf);
    }

    [Test]
    public void ComboObjectNonNullTest()
    {
        NUnit.Framework.Assert.That(characterInstance, !Is.Null);
    }
/*
    [Test]
    public void IncrementLevelTest()
    {
        SimonSaysPuzzle simonPuzzle = new SimonSaysPuzzle();
        simonPuzzle.level = 1;
        simonPuzzle.IncrementLevel();
        NUnit.Framework.Assert.AreEqual(2, simonPuzzle.level);

    }

    [Test]
    public void TrackUserInputTest()
    {
        red.id = 0;
        blue.id = 1;
        green.id = 2;
        yellow.id = 3;

        SimonSaysPuzzle simonPuzzle = new SimonSaysPuzzle();
        simonPuzzle.generatedSequence.Add(blue.id);
        simonPuzzle.generatedSequence.Add(green.id);
        simonPuzzle.TrackUserInput(blue);

        NUnit.Framework.Assert.AreEqual(simonPuzzle.generatedSequence[0], simonPuzzle.playerSequence[0]);

    }

    [UnityTest]
    public IEnumerator BeginSimonSaysClearsPlayerSequenceTest()
    {
        red.id = 0;
        blue.id = 1;
        green.id = 2;
        yellow.id = 3;
        SimonSaysPuzzle simonPuzzle = new SimonSaysPuzzle();
        simonPuzzle.playerSequence.Add(blue.id);
        simonPuzzle.playerSequence.Add(red.id);
        simonPuzzle.counter = 1;
        yield return simonPuzzle.BeginSimonSays();
        //Debug.Log(simonPuzzle.playerSequence[0]);
        NUnit.Framework.Assert.IsEmpty(simonPuzzle.playerSequence);
    }

    [UnityTest]
    public IEnumerator BeginSimonSaysClearsGeneratedSequenceTest()
    {

        SimonSaysPuzzle simonPuzzle = new SimonSaysPuzzle();
        simonPuzzle.generatedSequence.Add(blue.id);
        simonPuzzle.generatedSequence.Add(red.id);
        simonPuzzle.counter = 1;
        yield return simonPuzzle.BeginSimonSays();
        //Debug.Log(simonPuzzle.playerSequence[0]);
        NUnit.Framework.Assert.IsEmpty(simonPuzzle.generatedSequence);
    }
*/
}
