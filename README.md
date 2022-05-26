## Auto formatting hooked on git pre-format hook

- Create editor config file
	- in case of Visual Studio: `Solution -> Add new file -> .editorconfig`
- Create folder in project root, for example `.gih-hooks`
- Copy `.git/hooks/pre-commit.sample` to this new folder and rename it to `pre-commit`

```sh
#!/usr/bin/env sh

echo "pre-commit from dotnet-prettier custom .git-hooks"

#!/bin/sh
LC_ALL=C

# Select files to format
FILES=$(git diff --cached --name-only --diff-filter=ACM "*.cs" | sed 's| |\\ |g')
[ -z "$FILES" ] && exit 0

# Format all selected files
echo "$FILES" | cat | xargs | sed -e 's/ /,/g' | xargs dotnet format --include

# Add back the modified files to staging
echo "$FILES" | xargs git add

exit 0
```

- let GIT know, where hooks are placed
	- `git config core.hooksPath .\.git-hooks\`
- globally install `dotnet-format` package
	- `dotnet tool install --global dotnet-format`
