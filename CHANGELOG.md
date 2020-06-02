# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Changed
- Rename DoesMemoryMatch method to Compare (#22)
- Remove DataMatches property from IMemoryComparison interface (#22)
- Rename SetLogger method to SetApplicationLogger to help avoid confusion (#22)
- Sheet and range data is now cached to avoid expesive read operations on the provided sheet and range classes (#26)

### Added
- Add properties on the memory comparison object for the range address and sheet name before and after a change (#24)

## [0.1.0] - 2020-05-18

- Initial release
