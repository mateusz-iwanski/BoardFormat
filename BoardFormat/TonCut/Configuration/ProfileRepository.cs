using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    public class ProfileRepository
    {
        private int Version;
        private DefaultUnitsInput DefaultUnits;

        public ProfileRepository()
        {
            // 2 is default number of version 
            this.Version = 2;
            // defaults settings for DefaultUnitsInput
            this.DefaultUnits = new DefaultUnitsInput(_time: "s", _length: "mm", _field: "sqmm", _angle: "deg");
        }

        public ProfileRepository(DefaultUnitsInput _defaultUnits, int version)
        {
            this.DefaultUnits = _defaultUnits;
            this.Version = version;
        }

        public Configuration FromSmallProfileConfiguraion()
        {
            Algorithm algorithm = new Algorithm(
                grouping: true,
                deduction: true,
                lastStockItem: true,
                firstHit: true,
                fast: false,
                balance: false,
                new Forking(enabled: false, level: 1),
                new Adaptive(enabled: true, level: 5),
                new AI(enabled: false, level: 0)
                );

            Limits limits = new Limits(
                new MaxCombinations(enabled: false, limit: 5000000),
                new MaxTimeSingle(enabled: true, limit: 5),
                new MaxTime(enabled: false, limit: 0),
                new GoodEnoughWaste(enabled: false, limit: 0.0d)
                );

            StockOrder stockOrder = new StockOrder(
                order: new Order(
                    direction: "fromSmall", randomDrawCount: 10,
                    switchToSmall: new SwitchToSmall(enabled: false, minWaste: 0.2d),
                    randomOrders: new RandomOrders(enabled: false, count: 5)
                    ),
                adaptiveOrder: new AdaptiveOrder(
                    enabled: true, minWaste: 0.15d, maxTries: 3, maxCycles: 1)
                );

            Advanced advanced = new Advanced(
                new DynamicMethodSwitch(enabled: true, threshold: 1), 
                new FastMethodForLastStockItems(enabled: true, threshold: 0.8d), 
                new SearchPrecision(firstLevel: 2147483647, nextLevels: 1),
                searchDirectionOfStockItem: "auto");

            Profile profile = new Profile(name: "fromSmall", active: true, algorithms: algorithm, limits: limits, stockOrder: stockOrder, advanced: advanced);            

            Configuration config = new Configuration(_version: this.Version, _defaultUnits: this.DefaultUnits, _profiles: profile);            

            return config;
        }

        public Configuration FromLargeProfileConfiguration()
        {
            Configuration configuration = FromSmallProfileConfiguraion();


            StockOrder stockOrder = new StockOrder(
                order: new Order(
                    direction: "fromLarge", randomDrawCount: 10,  // changes between FromSmallProfileConfiguraion
                    switchToSmall: new SwitchToSmall(enabled: false, minWaste: 0.2d),
                    randomOrders: new RandomOrders(enabled: false, count: 5)
                    ),
                adaptiveOrder: new AdaptiveOrder(
                    enabled: true, minWaste: 0.15d, maxTries: 3, maxCycles: 1)
                );

            Profile profile = new Profile(name: "fromLarge", active: true,
                algorithms: configuration.profiles[0].algorithms, limits: configuration.profiles[0].limits,
                stockOrder : stockOrder, 
                advanced: configuration.profiles[0].advanced);

            return new Configuration(_version: this.Version, _defaultUnits: this.DefaultUnits, _profiles: profile);

        }

        public Configuration FromSmallProfileConfiguraionTest()
        {
            Algorithm algorithm = new Algorithm(
                grouping: true,
                deduction: true,
                lastStockItem: true,
                firstHit: true,
                fast: true,
                balance: false,
                new Forking(enabled: false, level: 1),
                new Adaptive(enabled: false, level: 5),
                new AI(enabled: false, level: 0)
                );

            Limits limits = new Limits(
                new MaxCombinations(enabled: false, limit: 5),
                new MaxTimeSingle(enabled: true, limit: 1),
                new MaxTime(enabled: true, limit: 2),
                new GoodEnoughWaste(enabled: false, limit: 0.0d)
                );

            StockOrder stockOrder = new StockOrder(
                new Order(
                    direction: "fromSmall", randomDrawCount: 5,
                    switchToSmall: new SwitchToSmall(enabled: false, minWaste: 0.2d),
                    randomOrders: new RandomOrders(enabled: false, count: 5)
                    ),
                adaptiveOrder: new AdaptiveOrder(
                    enabled: true, minWaste: 0.15d, maxTries: 3, maxCycles: 1)
                );

            Advanced advanced = new Advanced(
                new DynamicMethodSwitch(enabled: true, threshold: 1),
                new FastMethodForLastStockItems(enabled: true, threshold: 0.8d),
                new SearchPrecision(firstLevel: 2147483647, nextLevels: 1), //2147483647
                searchDirectionOfStockItem: "auto");

            Profile profile = new Profile(name: "fromSmall", active: true, algorithms: algorithm, limits: limits, stockOrder: stockOrder, advanced: advanced);

            Configuration config = new Configuration(_version: this.Version, _defaultUnits: this.DefaultUnits, _profiles: profile);

            return config;
        }

        public Configuration FromLargeProfileConfigurationTest()
        {
            Configuration configuration = FromSmallProfileConfiguraionTest();

            StockOrder stockOrder = new StockOrder(
                order: new Order(
                    direction: "fromLarge", randomDrawCount: 10,  // changes between FromSmallProfileConfiguraion
                    switchToSmall: new SwitchToSmall(enabled: false, minWaste: 0.2d),
                    randomOrders: new RandomOrders(enabled: false, count: 5)
                    ),
                adaptiveOrder: new AdaptiveOrder(
                    enabled: true, minWaste: 0.15d, maxTries: 3, maxCycles: 1)
                );

            Profile profile = new Profile(name: "fromLarge", active: true,
                algorithms: configuration.profiles[0].algorithms, limits: configuration.profiles[0].limits,
                stockOrder: stockOrder,
                advanced: configuration.profiles[0].advanced);

            return new Configuration(_version: this.Version, _defaultUnits: this.DefaultUnits, _profiles: profile);

        }

    }
}
