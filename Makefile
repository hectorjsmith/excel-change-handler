generateChangelog:
	./tools/git-chglog_linux_amd64 --config tools/chglog/config.yml v0.1.0.. > CHANGELOG.md

updateVersion:
	./tools/build/updateVersion.sh

build:
	./tools/build/build.sh
