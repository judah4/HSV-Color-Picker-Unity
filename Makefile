deploy:
	git subtree push --prefix Assets/HSVPicker origin upm

deploy-force:
	git push origin `git subtree split --prefix Assets/HSVPicker master`:upm --force
