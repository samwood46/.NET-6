using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;


public class WizardProcessor: IWizardProcessor
{
    public const int TotalSteps = 3;
    private int _currentStep = 1;
    public int GetCurrentStep()
    {
        return _currentStep;
    }
}
public interface IWizardProcessor
{
    int GetCurrentStep();
}

public class Result {
    public static void Main(string[] args)
    {
        ///Answer 1
        ///IWizardProcessor wizardProcessor = new();
        /// Console.WriteLine($"Dialog total steps: {wizardProcessor.TotalSteps}");
        ///
        ///Answer 2
        Console.WriteLine($"Dialog total steps: {WizardProcessor.TotalSteps}");
        /// 
        /// Answer 3
        /// totalStepsMember = typeof(IWizardProcessor).GetMembers().First(member => member.Name == "TotalSteps");
        ///Console.WriteLine($"Dialog total steps: {((FieldInfo)totalStepsMember).GetValue(new WizardProcessor())}");
    }
}





