# Git notes

## Task 15 — Basic git

### Commands
- Created the local eature/git-basics and eature/git-basics-conflict branches.
- Committed the README changes with Conventional Commit messages.
- Merged eature/git-basics-conflict into eature/git-basics and resolved the README conflict.

### Output (git log --graph --oneline --all)
``
*   0652716 merge: task 15 - resolve readme conflict |\   | * ecd0e35 docs: task 15 - conflict branch change * | 919646f docs: task 15 - feature branch change * | 78a11c2 docs: task 15 - conflict branch change |/   * fb6cf4c docs: task 15 - add practicum readme * 939bbd6 refactor reorganize LevelMenu structure * e4fc41d Delete Tasks/Level1/Task01_HelloWorld.cs | * 0b1ee75 Refactor input parsing in Task03_Calculator | * 6556910 Fix decimal variable suffix in Task02_Paremens | * 78a4d71 feat: add tasks02-05 | * 974fcdc Delete Task01_HelloWorld.cs | * 2fed09e feat: task 01 - hello world |/   | * dc513a1 Delete Tasks/Level1 directory |/   | * 2d36ade Delete Tasks/Level1 directory |/   * ce18eb4 Add files via upload
``

### What I learned
A merge conflict occurs when branches change the same lines. After editing out the conflict markers, staging the file and committing completes the merge.

## Task 35 — .gitignore, .editorconfig, PR and rebase

### Commands
- Added the required ignore patterns and editor settings in a separate commit.


- Created feature/task-35 and recorded the task implementation commits.


- Prepared the three git-notes commits for interactive squash.

