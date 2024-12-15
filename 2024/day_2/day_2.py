import typing
import pathlib


def valid_max_difference(report: typing.List[int], difference: int) -> bool:
    """"""
    for index in range(1, len(report)):
        if abs(report[index - 1] - report[index]) > difference:
            return False
    return True


def valid_min_difference(report: typing.List[int], difference: int) -> bool:
    """"""
    for index in range(1, len(report)):
        if abs(report[index - 1] - report[index]) < difference:
            return False
    return True


def all_increasing(report: typing.List[int]) -> bool:
    """"""
    for index in range(1, len(report)):
        if report[index - 1] > report[index]:
            return False
    return True


def all_decreasing(report: typing.List[int]) -> bool:
    """"""
    for index in range(1, len(report)):
        if report[index - 1] < report[index]:
            return False
    return True


def process_safe_reports(reports: typing.List[typing.List[int]]) -> int:
    """"""

    number_safe_reports = 0

    for report in reports:
        # Check increase or decrease
        all_incr = all_increasing(report)
        all_decr = all_decreasing(report)
        valid_max_diff = valid_max_difference(report, 3)
        valid_min_diff = valid_min_difference(report, 1)

        print(f"""
              {report}
              All increase: {all_incr}
              All decrease: {all_decr}
              res = {(all_incr or all_decr)}
              Valid max difference: {valid_max_diff}
              Valid min difference: {valid_min_diff}
              res = {valid_max_diff and valid_min_diff}
              final res = {(all_incr or all_decr) and (valid_max_diff and valid_min_diff)}
              """)

        if (all_incr or all_decr) and (valid_max_diff and valid_min_diff):
            number_safe_reports += 1

    return number_safe_reports


def parse_input(
    puzzle_input_path: pathlib.Path = pathlib.Path("puzzle_input.txt"),
) -> typing.List[typing.List[int]]:
    """"""
    reports: typing.List[typing.List[int]] = []

    with puzzle_input_path.open("r") as puzzle_input:
        for line in puzzle_input.readlines():
            split_int_line = [int(value.strip()) for value in line.split(" ")]
            reports.append(split_int_line)

    print(f"Parsed {len(reports)} reports.")

    return reports


if __name__ == "__main__":
    reports = parse_input()
    number_safe_reports = process_safe_reports(reports)
    print(f"Number of safe reports: {number_safe_reports}")
