# Commits and Commit Messages
We use the [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) specification for commit messages. This means that all commit messages must follow the following format:
```text
<type>(optional scope): <description>
```

## Type
The `type` specifies the overall type of change that the commit makes. The following types are valid:
* `build`: Changes that affect the build system or external dependencies (example scopes: `npm`, `circleci`, `docker`, `jenkins`)
* `ci`: Changes to our CI configuration files and scripts (example scopes: `circleci`, `github actions`, `jenkins`)
* `chore`: Other changes that don't modify `src` or `test` files
* `docs`: Documentation only changes
* `feat`: A new feature
* `fix`: A bug fix
* `perf`: A code change that improves performance
* `refactor`: A code change that neither fixes a bug nor adds a feature
* `revert`: Reverts a previous commit
* `style`: Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)
* `test`: Adding missing tests or correcting existing tests

## Scope
The `scope` is optional. It is used to specify a section of the codebase. For example, if you are fixing a bug in the `order` model, you might use the scope `order`.

## Description
The `description` is a short description of the change. It should be written in the imperative, present tense. For example, "change" not "changed" or "changes".

It should be no longer than 50 characters.

It should also be meanningful. For example, "fix order" is not a good description. "fix(order): fix order creation" is a better description.

## Putting it all together
Here is an example of a valid commit message:
```text
fix(order): fix order creation
```

```
feat(barview): add bar name to barview
```

```
ci: run tests on push
```

```
style: fix linting errors
```

### Questions
For questions about this document, please raise an issue on this repository.

### Contributing
If you would like to contribute to this document, please raise a pull request on this repository.
We're always looking for ways to improve our processes!