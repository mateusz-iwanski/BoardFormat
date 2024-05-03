using System.Collections.Generic;
using TonCut;

public class Settings
{
    public int CutterVersion { get; set; }
    public CutterDefaultsUnits CutterDefaultsUnits { get; set; }
    public CutterMaterial CutterMaterial { get; set; }
    public CutterRauseWaste CutterRauseWaste { get; set; }
    public CutterWasteEdging CutterWasteEdging { get; set; }
    public CutterPiece CutterPiece { get; set; }
    public CutterStockItem CutterStockItem { get; set; }
    public CutterEdging CutterEdging { get; set; }
    public CutterVeneer18 CutterVeneer18 { get; set; }
    public CutterVeneer38 CutterVeneer38 { get; set; }
    public CutterDevice CutterDevice { get; set; }
    public CutterConfiguration CutterConfiguration { get; set; }
}

public class CutterDefaultsUnits
{
    public string time { get; set; }
    public string percent { get; set; } 
    public string length { get; set; } 
    public string field { get; set; } 
    public string angle { get; set; } 
}

public class CutterMaterial
{
    public int deviceId { get; set; }
    public string kind { get; set; }
    public int width { get; set; }
    public bool canMirror { get; set; }
    public int surplus { get; set; }
    public bool surplusEditable { get; set; }
    public int margin { get; set; }
    public bool marginEditable { get; set; }
    public int defaultEdging { get; set; }
    public string cuttingDimensions { get; set; }
    public bool canBeVeneered { get; set; }
    public double kerf { get; set; }
    public bool allowEdgeCuts { get; set; }
}

public class CutterRauseWaste
{
    public int minLongerLength { get; set; }
    public int minShorterLength { get; set; }
}
public class CutterWasteEdging
{
    public bool enabled { get; set; }
    public int _default { get; set; }
}

public class CutterPiece
{
    public string shapeType { get; set; }
    public string priority { get; set; }
    public int surplus { get; set; }
    public int margin { get; set; }
}

public class CutterStockItem
{
    public string priority { get; set; }
    public double kerfSize { get; set; }
}

public class CutterEdging
{
    public double left { get; set; }
    public double right { get; set; }
    public double top { get; set; }
    public double bottom { get; set; }
}

public class CutterVeneer18
{
    public int width { get; set; }
    public int thickness { get; set; }
    public double maxMaterialThickness { get; set; }
}

public class CutterVeneer38
{
    public int width { get; set; }
    public int thickness { get; set; }
    public double maxMaterialThickness { get; set; }
}

public class CutterDevice
{
    public int id { get; set; }
    public string title { get; set; }
    public string materialKind { get; set; }
    public bool canCrossCuts { get; set; }
    public bool fullCutsOnly { get; set; }
    public bool stripCuts { get; set; }
    public int minCutWidth { get; set; }
    public string edgingCuts { get; set; }
    public string originEdgingCuts { get; set; }
    public string firstCutDirection { get; set; }

    public CutterMaxCutDepth CutterMaxCutDepth { get; set; }
    public CutterMaxCutLengthByLength CutterMaxCutLengthByLength { get; set; }
    public CutterMaxCutLengthByWidth CutterMaxCutLengthByWidth { get; set; }
    public CutterSlants CutterSlants {  get; set; }
}

public class CutterMaxCutDepth
{
    public bool enabled { get; set;}
    public int limit { get; set; }
    public bool includeEdging { get; set; }
}

public class CutterMaxCutLengthByLength
{
    public bool enabled { get; set; }
    public double limit { get; set; }
}
public class CutterMaxCutLengthByWidth
{
    public bool enabled { get; set; }
    public double limit { get; set; }

}
public class CutterSlants
{
    public bool supported { get; set; }
    public string leftMeasurement { get; set; }
    public string rightMeasurement { get; set; }
}

public class CutterConfiguration
{
    public CutterAlgorithm CutterAlgorithm { get; set; }
    public CutterLimits CutterLimits { get; set; }
    public CutterStockOrder CutterStockOrder { get; set; }
    public CutterAdvanced CutterAdvanced { get; set; }
}

public class CutterAlgorithm
{
    public bool grouping { get; set; }
    public bool deduction { get; set; }
    public bool lastStockItem { get; set; }
    public bool firstHit { get; set; }
    public bool fast { get; set; }
    public bool balance { get; set; }
    //Forking object
    public bool forkingEnabled { get; set; }
    public int forkingLevel { get; set; }
    // Adaptive object
    public bool adaptiveEnabled { get; set; }
    public int adaptiveLevel { get; set; }
    //AI object
    public bool aiEnabled { get; set; }
    public int aiLevel { get; set;}
}

public class CutterLimits
{
    // MaxCombinations object
    public bool maxCombinationsEnabled {  get; set; }
    public int maxCombinationsLimit {  get; set; }
    // MaxTimeSingle object
    public bool maxTimeSingleEnabled {  get; set; }
    public int maxTimeSingleLimit {  get; set; }
    // MaxTime object
    public bool maxTimeEnabled { get; set; }
    public int maxTimeLimit {  get; set; }
    // GoodEnoughWaste object
    public bool goodEnoughWasteEnabled { get; set; }
    public double goodEnoughWasteLimit { get; set; }
}

public class CutterStockOrder
{ 
     // Order object
    public string orderDirection { get; set; }
    public int randomDrawCount { get; set; }
    // SwitchToSmall object
    public bool switchToSmallEnabled { get; set; }
    public double switchToSmallMinWaste { get; set; }
    // RandomOrders object
    public bool randomOrdersEnabled { get; set; }
    public int randomOrdersCount { get; set; }
    // AdaptiveOrder object
    public bool adaptiveOrderEnabled {  get; set; }
    public double adaptiveOrderMinWaste { get; set ; }
    public int adaptiveOrderMaxTries { get; set; }
    public int adaptiveOrderMaxCycles { get; set; }
}

public class CutterAdvanced
{
    // DynamicMethodSwitch object
    public bool dynamicMethodSwitchEnabled { get; set; }
    public int dynamicMethodSwitchThreshold { get; set; }
    // FastMethodForLastStockItems object
    public bool fastMethodForLastStockItemsEnabled { get; set; }
    public double fastMethodForLastStockItemsThreshold { get; set; }
    // SearchPrecision object
    public int searchPrecisionFirstLevel { get; set; }
    public int searchPrecisionNextLevels { get; set; }
    // END objects
    public string searchDirectionOfStockItem { get; set; }
}