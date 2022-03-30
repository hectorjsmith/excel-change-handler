# CHANGELOG

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog], and this project adheres to [Semantic Versioning].

## [Unreleased]
*Nothing yet*

## [v0.5.0] - 2022-03-30
### Bug Fixes
- (69c6e09) fix: generate documentation in nupkg file ([#38](https://gitlab.com/hectorjsmith/excel-change-handler/issues/38))

### Features
- (0abe002) feat: support for change event filters ([#21](https://gitlab.com/hectorjsmith/excel-change-handler/issues/21))
- (65bac17) feat: support system.action as change handler ([#29](https://gitlab.com/hectorjsmith/excel-change-handler/issues/29))
- (4b2b0de) feat: wrap exceptions thrown accessing excel data ([#19](https://gitlab.com/hectorjsmith/excel-change-handler/issues/19))

### Merge Requests
- (dd03133) Merge branch 'docs/update-documentation-site-with-latest-features' into 'main'
- (333791a) Merge branch '21-support-for-change-event-filtering' into 'main'
- (2b12892) Merge branch '38-nuget-file-does-not-include-docs' into 'main'
- (dbe2c93) Merge branch 'docs/add-all-missing-code-documentation' into 'main'
- (ae022de) Merge branch '23-support-ordering-handlers' into 'main'
- (7c47920) Merge branch '29-support-adding-system-action-objects-as-handlers' into 'main'
- (8836e2b) Merge branch '19-protect-dangerous-methods-with-try-catch' into 'main'
- (cdba4a2) Merge branch '31-add-gif-of-library-in-action' into 'main'
- (daca014) Merge branch 'docs/update-nuget-badges' into 'main'
- (f9fff87) Merge branch 'release/0.4.0' into 'main'

## [v0.4.0] - 2022-01-06
### Bug Fixes
- (c91ca6c) fix: prevent int overflow when calculating range size ([#37](https://gitlab.com/hectorjsmith/excel-change-handler/issues/37))

### Features
- (2f3cddf) feat: include size of range in change properties
- (af3df58) feat: new property to flag is sheet size has changed
- (8d7de24) feat: new data class to store change properties ([#25](https://gitlab.com/hectorjsmith/excel-change-handler/issues/25))
- (cb90144) feat: rename library to remove csharp reference ([#35](https://gitlab.com/hectorjsmith/excel-change-handler/issues/35))

### BREAKING CHANGE
- All references to range size now stored as long variables instead of int
- Replaced before and after properties on the `IMemoryComparison` object with new data classes
- Library and all namespaces renamed to `ExcelChangeHandler`

### Merge Requests
- (16c8357) Merge branch '37-range-size-overflows-int-type' into 'main'
- (cdf09e0) Merge branch 'docs/prune-readme-file' into 'main'
- (a139502) Merge branch 'docs/restructure-documentation-site' into 'main'
- (01a0fd4) Merge branch '36-deploy-documentation-site' into 'main'
- (aecb37b) Merge branch 'feat/include-size-of-range-in-comparison' into 'main'
- (5bfbf06) Merge branch 'feat/new-has-sheet-size-changed-property' into 'main'
- (beeeef6) Merge branch '34-treat-all-warnings-as-errors' into 'main'
- (3c99127) Merge branch '25-add-new-memory-object' into 'main'
- (fd129b9) Merge branch '35-rename-library-to-remove-csharp' into 'main'
- (9b00af8) Merge branch 'docs/add-nuget-badge-to-readme' into 'main'
- (0b31e5c) Merge branch 'release/v0.3.0' into 'main'

## [v0.3.0] - 2021-01-22
### Features
- (ae13935) feat: support setting max memory size ([#30](https://gitlab.com/hectorjsmith/excel-change-handler/issues/30))
- (cbceab9) feat: auto-generate project changelog based on commits ([#33](https://gitlab.com/hectorjsmith/excel-change-handler/issues/33))

### Merge Requests
- (abd6ea2) Merge branch '32-publish-library-to-nuget' into 'main'
- (67ae1c3) Merge branch '30-support-custom-max-memory-cache-size' into 'main'
- (5b70054) Merge branch 'ci/simplify-gitlab-ci-pipeline' into 'main'
- (4e87f41) Merge branch '33-auto-generate-changelog-using-commit-messages' into 'main'
- (2e1fc0d) Merge branch 'chore/update-default-branch-to-main' into 'main'
- (20ce562) Merge branch 'fix-pipeline-status-badge' into 'develop'

### BREAKING CHANGE

- The CHANGELOG file no longer includes detailed release notes for previous versions.

## [v0.2.0] - 2020-06-08
### Reverts
- (c586c98) [#24](https://gitlab.com/hectorjsmith/excel-change-handler/issues/24): Set memory when sheet data not set

### Merge Requests
- (53f2932) Merge branch 'bugfix/fix-build-script-path' into 'master'
- (09be066) Merge branch '27-refactor-library-to-support-retaining-types-for-handlers' into 'master'
- (a2fa612) Merge branch '28-rename-library-to-changehandler' into 'master'
- (ab2a9d2) Merge branch '22-improve-library-usability' into 'master'
- (a5cbdaa) Merge branch 'master' into '22-improve-library-usability'
- (ab9835a) Merge branch '26-cache-data-from-excel-wrappers' into 'master'
- (34d12dc) Merge branch 'master' into '22-improve-library-usability'
- (f716373) Merge branch '24-not-recognizing-new-rows-when-no-memory-set' into 'master'


## [v0.1.0] - 2020-05-18
### Merge Requests
- (19eac68) Merge branch 'release/v0.1.0' into 'master'
- (0b97871) Merge branch '6-update-readme' into 'master'
- (a8e38df) Merge branch '20-log-test-results-in-gitlab' into 'master'
- (5fda355) Merge branch 'develop' into 'master'
- (afc6f5c) Merge branch '18-simple-change-logger-not-working' into 'develop'
- (8b564d9) Merge branch '17-only-package-nuget-package-on-certain-branches' into 'develop'
- (020e7cc) Merge branch '17-only-package-nuget-package-on-certain-branches' into 'develop'
- (0ae66fe) Merge branch '14-support-for-logging-changes-as-they-happen' into 'develop'
- (9e99440) Merge branch '16-generalize-highlighter-concept' into 'develop'
- (71206a1) Merge branch '5-build-nuget-package-in-gitlab' into 'develop'
- (fef7147) Merge branch '8-detect-and-highlight-row-adds' into 'develop'
- (4a4d145) Merge branch '15-refactor-static-classes' into 'develop'
- (5771ad0) Merge branch '9-option-to-enable-disable-change-highlighting' into 'develop'
- (12c87af) Merge branch '13-decouple-highlighter-code-from-handler' into 'develop'
- (1aa7b56) Merge branch '12-library-crashing-when-using-auto-fill' into 'develop'
- (2f7f581) Merge branch '10-library-crashes-on-very-large-sheet' into 'develop'
- (a3c336b) Merge branch '11-remove-rgb-references' into 'develop'
- (1754dd5) Merge branch '3-excel-addin-project' into 'develop'
- (841e180) Merge branch '7-only-highlight-ranges-that-have-actually-changed' into 'develop'
- (70ccf1e) Merge branch '4-implement-basic-highlighter' into 'develop'
- (90d97f2) Merge branch '2-create-library-public-api' into 'develop'
- (6067593) Merge branch '1-initial-project-setup' into 'develop'

---

*This changelog is automatically generated by [git-chglog]*

[Keep a Changelog]: https://keepachangelog.com/en/1.0.0/
[Semantic Versioning]: https://semver.org/spec/v2.0.0.html
[git-chglog]: https://github.com/git-chglog/git-chglog
[Unreleased]: https://gitlab.com/hectorjsmith/excel-change-handler/compare/v0.5.0...main
[v0.5.0]: https://gitlab.com/hectorjsmith/excel-change-handler/compare/v0.4.0...v0.5.0
[v0.4.0]: https://gitlab.com/hectorjsmith/excel-change-handler/compare/v0.3.0...v0.4.0
[v0.3.0]: https://gitlab.com/hectorjsmith/excel-change-handler/compare/v0.2.0...v0.3.0
[v0.2.0]: https://gitlab.com/hectorjsmith/excel-change-handler/compare/v0.1.0...v0.2.0
[v0.1.0]: https://gitlab.com/hectorjsmith/excel-change-handler/compare/v0.0.0...v0.1.0
