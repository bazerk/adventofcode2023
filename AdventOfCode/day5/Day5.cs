using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Runtime.Intrinsics;

namespace AdventOfCode.day5;

public static class Day5 {

    private class Range {
        public long DestinationStart { get; init; }
        public long SourceStart { get; init; }
        public long SourceEnd => SourceStart + Length - 1;
        public long Length { get; init; }

        public long MappedValue(long source) {
            if (source < SourceStart) {
                return -1;
            }

            var diff = source - SourceStart;
            if (diff > Length) {
                return -1;
            }

            return DestinationStart + diff;
        }
    }
    
    private class DataSet {
        public List<long> Seeds { get; set; }
        public List<(long, long)> SeedRanges { get; set; }
        public List<Range> SeedToSoil { get; set; }
        public List<Range> SoilToFertilizer { get; set; }
        public List<Range> FertilizerToWater { get; set; }
        public List<Range> WaterToLight { get; set; }
        public List<Range> LightToTemperature { get; set; }
        public List<Range> TemperatureToHumidity { get; set; }
        public List<Range> HumidityToLocation { get; set; }
    }

    private static long MapValue(long value, List<Range> ranges) {
        foreach (var range in ranges) {
            var mapped = range.MappedValue(value);
            if (mapped != -1) return mapped;
        }
        return value;
    }

    private static List<(long, long)> MapRange(List<(long, long)> value, List<Range> ranges) {
        var mapped = new List<(long, long)>();
        ranges.Sort((r1, r2) => r1.SourceStart.CompareTo(r2.SourceStart));
        foreach (var (initx1, initx2) in value) {
            var x1 = initx1;
            var x2 = initx2;
            var fullyMapped = false;
            foreach (var range in ranges) {
                if (x1 > range.SourceEnd) continue;
                if (x2 < range.SourceStart) {
                    mapped.Add((x1, x2));
                    fullyMapped = true;
                    break;
                }

                if (x1 < range.SourceStart) {
                    mapped.Add((x1, range.SourceStart-1));
                    x1 = range.SourceStart;
                }

                if (x2 <= range.SourceEnd) {
                    mapped.Add((range.MappedValue(x1), range.MappedValue(x2)));
                    fullyMapped = true;
                    break;
                }
                
                mapped.Add((range.MappedValue(x1), range.MappedValue(range.SourceEnd)));
                x1 = range.SourceEnd + 1;
            }

            if (!fullyMapped) {
                mapped.Add((x1, x2));
            }
        }
        return mapped;
    }

    private static DataSet LoadDataSet(string inputFile) {
        var data = new DataSet();
        List<Range>? rangeList = null;
        foreach (var line in File.ReadLines(inputFile)) {
            if (string.IsNullOrWhiteSpace(line)) continue;
            if (line.StartsWith("seeds")) {
                var seedString = line.Substring("seeds: ".Length).Split(" ", StringSplitOptions.RemoveEmptyEntries);
                data.Seeds = seedString.Select(long.Parse).ToList();
                data.SeedRanges = new List<(long, long)>();
                for (var ix = 0; ix < data.Seeds.Count; ix += 2) {
                    data.SeedRanges.Add((data.Seeds[ix], data.Seeds[ix] + data.Seeds[ix+1] - 1));
                }
            } else if (line.StartsWith("seed-to-soil")) {
                rangeList = new List<Range>();
                data.SeedToSoil = rangeList;
            } else if (line.StartsWith("soil-to-fertilizer")) {
                rangeList = new List<Range>();
                data.SoilToFertilizer = rangeList;
            } else if (line.StartsWith("fertilizer-to-water")) {
                rangeList = new List<Range>();
                data.FertilizerToWater = rangeList;
            } else if (line.StartsWith("water-to-light")) {
                rangeList = new List<Range>();
                data.WaterToLight = rangeList;
            } else if (line.StartsWith("light-to-temperature")) {
                rangeList = new List<Range>();
                data.LightToTemperature = rangeList;
            } else if (line.StartsWith("temperature-to-humidity")) {
                rangeList = new List<Range>();
                data.TemperatureToHumidity = rangeList;
            } else if (line.StartsWith("humidity-to-location")) {
                rangeList = new List<Range>();
                data.HumidityToLocation = rangeList;
            } else {
                var split = line.Split(" ");
                rangeList.Add(new Range {
                    DestinationStart = long.Parse(split[0]),
                    SourceStart = long.Parse(split[1]),
                    Length = long.Parse(split[2]),
                });
            }
        }

        return data;
    }
    
    public static long SolveStar1(string inputFile = "day5/input.txt") {
        var lowest = long.MaxValue;
        var data = LoadDataSet(inputFile);
        foreach (var seed in data.Seeds) {
            var soil = MapValue(seed, data.SeedToSoil);
            var fert = MapValue(soil, data.SoilToFertilizer);
            var water = MapValue(fert, data.FertilizerToWater);
            var light = MapValue(water, data.WaterToLight);
            var temp = MapValue(light, data.LightToTemperature);
            var humidity = MapValue(temp, data.TemperatureToHumidity);
            var loc = MapValue(humidity, data.HumidityToLocation);
            lowest = long.Min(loc, lowest);
        }
        return lowest;
    }
    
    public static long SolveStar2(string inputFile = "day5/input.txt") {
        var data = LoadDataSet(inputFile);
        var ranges = data.SeedRanges;
        ranges = MapRange(ranges, data.SeedToSoil);
        ranges = MapRange(ranges, data.SoilToFertilizer);
        ranges = MapRange(ranges, data.FertilizerToWater);
        ranges = MapRange(ranges, data.WaterToLight);
        ranges = MapRange(ranges, data.LightToTemperature);
        ranges = MapRange(ranges, data.TemperatureToHumidity);
        ranges = MapRange(ranges, data.HumidityToLocation);
        
        var lowest = long.MaxValue;
        foreach (var (x1, x2) in ranges) {
            lowest = long.Min(x1, lowest);
        }
        
        return lowest;
    }
}