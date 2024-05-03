using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TonCut;

namespace BoardFormat.CutterBuilder 
{
    public class ProfileBuilder : BaseCutterBuilder, ICutterConfigInputBuilder
    {
        Algorithm algorithm;
        Limits limits;
        StockOrder stockOrder;
        Advanced advanced;

        public ProfileBuilder()
        {
            limits = new Limits(
                new MaxCombinations(
                    enabled: settings.CutterConfiguration.CutterLimits.maxCombinationsEnabled,
                    limit: settings.CutterConfiguration.CutterLimits.maxCombinationsLimit
                    ),
                new MaxTimeSingle(
                    enabled: settings.CutterConfiguration.CutterLimits.maxTimeSingleEnabled,
                    limit: settings.CutterConfiguration.CutterLimits.maxTimeSingleLimit
                    ),
                new MaxTime(
                    enabled: settings.CutterConfiguration.CutterLimits.maxTimeEnabled,
                    limit: settings.CutterConfiguration.CutterLimits.maxTimeLimit
                    ),
                new GoodEnoughWaste(
                    enabled: settings.CutterConfiguration.CutterLimits.goodEnoughWasteEnabled,
                    limit: (double)settings.CutterConfiguration.CutterLimits.goodEnoughWasteLimit
                    )
                );


            algorithm = new Algorithm(
                grouping: settings.CutterConfiguration.CutterAlgorithm.grouping,
                deduction: settings.CutterConfiguration.CutterAlgorithm.deduction,
                lastStockItem: settings.CutterConfiguration.CutterAlgorithm.lastStockItem,
                firstHit: settings.CutterConfiguration.CutterAlgorithm.firstHit,
                fast: settings.CutterConfiguration.CutterAlgorithm.fast,
                balance: settings.CutterConfiguration.CutterAlgorithm.balance,
                new Forking(
                    enabled: settings.CutterConfiguration.CutterAlgorithm.forkingEnabled,
                    level: settings.CutterConfiguration.CutterAlgorithm.forkingLevel
                    ),
                new Adaptive(
                    enabled: settings.CutterConfiguration.CutterAlgorithm.adaptiveEnabled,
                    level: settings.CutterConfiguration.CutterAlgorithm.adaptiveLevel
                    ),
                new AI(
                    enabled: settings.CutterConfiguration.CutterAlgorithm.aiEnabled,
                    level: settings.CutterConfiguration.CutterAlgorithm.aiLevel
                    )
                );

            

            stockOrder = new StockOrder(
                new Order(
                    direction: settings.CutterConfiguration.CutterStockOrder.orderDirection,
                    randomDrawCount: settings.CutterConfiguration.CutterStockOrder.randomDrawCount,
                    switchToSmall: new SwitchToSmall(
                        enabled: settings.CutterConfiguration.CutterStockOrder.switchToSmallEnabled,
                        minWaste: (double)settings.CutterConfiguration.CutterStockOrder.switchToSmallMinWaste
                        ),
                    randomOrders: new RandomOrders(
                        enabled: settings.CutterConfiguration.CutterStockOrder.randomOrdersEnabled,
                        count: settings.CutterConfiguration.CutterStockOrder.randomOrdersCount
                        )
                    ),
                adaptiveOrder: new AdaptiveOrder(
                    enabled: settings.CutterConfiguration.CutterStockOrder.adaptiveOrderEnabled,
                    minWaste: (double)settings.CutterConfiguration.CutterStockOrder.adaptiveOrderMinWaste,
                    maxTries: settings.CutterConfiguration.CutterStockOrder.adaptiveOrderMaxTries,
                    maxCycles: settings.CutterConfiguration.CutterStockOrder.adaptiveOrderMaxCycles
                    )
                );

            advanced = new Advanced(
                new DynamicMethodSwitch(
                    enabled: settings.CutterConfiguration.CutterAdvanced.dynamicMethodSwitchEnabled,
                    threshold: settings.CutterConfiguration.CutterAdvanced.dynamicMethodSwitchThreshold
                    ),
                new FastMethodForLastStockItems(
                    enabled: settings.CutterConfiguration.CutterAdvanced.fastMethodForLastStockItemsEnabled,
                    threshold: (double)settings.CutterConfiguration.CutterAdvanced.fastMethodForLastStockItemsThreshold
                    ),
                new SearchPrecision(
                    firstLevel: settings.CutterConfiguration.CutterAdvanced.searchPrecisionFirstLevel,
                    nextLevels: settings.CutterConfiguration.CutterAdvanced.searchPrecisionNextLevels
                    ), //2147483647
                searchDirectionOfStockItem: settings.CutterConfiguration.CutterAdvanced.searchDirectionOfStockItem
                );

            
        }
        public DataGroupInput Build() =>
            new Profile(
                name: "default", 
                active: true, 
                algorithms: algorithm, 
                limits: limits, 
                stockOrder: stockOrder, 
                advanced: advanced
                );
    }
}
