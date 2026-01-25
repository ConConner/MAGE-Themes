## [1.12.3](https://github.com/ConConner/MAGE-Themes/compare/v1.12.2...v1.12.3) (2026-01-25)


### Bug Fixes

* clipdata cannot be placed without a tile selection ([c8c4ec9](https://github.com/ConConner/MAGE-Themes/commit/c8c4ec93fe7263068f7d84c3540d3581f3b192b0)), closes [#68](https://github.com/ConConner/MAGE-Themes/issues/68)

## [1.12.2](https://github.com/ConConner/MAGE-Themes/compare/v1.12.1...v1.12.2) (2026-01-25)


### Bug Fixes

* large area image exports can crash the program ([0ae6e4a](https://github.com/ConConner/MAGE-Themes/commit/0ae6e4af4637d07d803637f0edff558b3995bf19))

## [1.12.1](https://github.com/ConConner/MAGE-Themes/compare/v1.12.0...v1.12.1) (2026-01-13)


### Bug Fixes

* picking a color in unused graphics editor space crashes the program ([cb3d723](https://github.com/ConConner/MAGE-Themes/commit/cb3d723ed25a978a0a2797c493bb4630205b801b))

# [1.12.0](https://github.com/ConConner/MAGE-Themes/compare/v1.11.1...v1.12.0) (2026-01-13)


### Bug Fixes

* map editor does not discard changes after manually saving and swapping maps ([876628b](https://github.com/ConConner/MAGE-Themes/commit/876628b756fe184e0bfc2cbdc94d1bdc0a4230e3))


### Features

* added button to edit graphics in tile table editor ([f0f3533](https://github.com/ConConner/MAGE-Themes/commit/f0f3533d3cbf9d51860ba2fb5bcf13225f6dc178))
* new graphics editor [experimental] ([284b26e](https://github.com/ConConner/MAGE-Themes/commit/284b26e0824ff9ccf2594ecdd20e740d5a1de381))
* room editor selection is animated (might be removed again later) ([54c59a6](https://github.com/ConConner/MAGE-Themes/commit/54c59a6157ec4e96b111cfb5cffc80aa1e18641c))
* select multiple rooms to exclude at once in area export ([8ecbd43](https://github.com/ConConner/MAGE-Themes/commit/8ecbd4362b958521c46fb6d0bef4d3f965c5c0f9))

## [1.11.1](https://github.com/ConConner/MAGE-Themes/compare/v1.11.0...v1.11.1) (2026-01-03)


### Bug Fixes

* bookmarks become uneditable when opening bookmark window without prior bookmark selection ([6a51150](https://github.com/ConConner/MAGE-Themes/commit/6a51150a5a40e831cc08deedb3b46b3ca98556db))
* map editor is missing button to edit map graphics ([d20ec30](https://github.com/ConConner/MAGE-Themes/commit/d20ec3028269eb9b26322be84f7c2f3abc221544))
* map editor is missing selected tile-id display ([fd9d4a8](https://github.com/ConConner/MAGE-Themes/commit/fd9d4a8a2b9d6c8117c4616a87b818407a03ed76))
* map editor is missing unexplored (visual) map type for metroid fusion ([2becb87](https://github.com/ConConner/MAGE-Themes/commit/2becb879030ba7b4ed7b5b973b16cb5acfecea02))

# [1.11.0](https://github.com/ConConner/MAGE-Themes/compare/v1.10.0...v1.11.0) (2025-12-12)


### Bug Fixes

* importing a tileset with a different height may squash the tile view until resize ([7ce6425](https://github.com/ConConner/MAGE-Themes/commit/7ce6425536520022fcee1f127ad98cf6ac7f8d85))
* map editor does sometimes not discard changes when swapping maps ([fb7b2b9](https://github.com/ConConner/MAGE-Themes/commit/fb7b2b9398946c200fc70bbc8f5e59556cf8c596))
* project bookmarks cannot be properly renamed ([d1c10d9](https://github.com/ConConner/MAGE-Themes/commit/d1c10d91728fee687751fbe985d2b1c9762875a3))
* values cannot be set for global bookmarks ([354e237](https://github.com/ConConner/MAGE-Themes/commit/354e2376bd78e408533b485e70d60c0f75dbea66))


### Features

* added new controls to bookmarks to reduce context menu usage ([c65275d](https://github.com/ConConner/MAGE-Themes/commit/c65275d6762e1471a3aa2ded4f14666f6c3b73b2))
* upgrade to .NET version 10 ([9b1a4c4](https://github.com/ConConner/MAGE-Themes/commit/9b1a4c4773c52e4e38c968375cadea4bc8333044))

# [1.10.0](https://github.com/ConConner/MAGE-Themes/compare/v1.9.2...v1.10.0) (2025-10-12)


### Features

* backup name format can be specified ([51da9b6](https://github.com/ConConner/MAGE-Themes/commit/51da9b61c44041eed40df5e48a986f20cba83fbf))
* backups can be saved under a ./backups/ directory ([b086e1f](https://github.com/ConConner/MAGE-Themes/commit/b086e1f2b4562743b81f6d837fc9a8711becce4e))
* backups can be set to be created periodically ([233eb28](https://github.com/ConConner/MAGE-Themes/commit/233eb2828bd19bb7e35b25d89f6b75028be62503))

## [1.9.2](https://github.com/ConConner/MAGE-Themes/compare/v1.9.1...v1.9.2) (2025-09-30)


### Bug Fixes

* color behind bg3 option does not display the current color after reload ([c83fb1f](https://github.com/ConConner/MAGE-Themes/commit/c83fb1fde05069578fd40770786e6fb5c4983d03))

## [1.9.1](https://github.com/ConConner/MAGE-Themes/compare/v1.9.0...v1.9.1) (2025-09-28)


### Bug Fixes

* accent contrast color would sometimes result in illegible text ([f37bc0c](https://github.com/ConConner/MAGE-Themes/commit/f37bc0c9f81a41a3a39291b2382234f1586aaf6c))
* changing a theme directly after opening the preferences menu sets every color to the background color ([7b705b3](https://github.com/ConConner/MAGE-Themes/commit/7b705b3b732e3dd4501a25cc9a87134efd80a10a))
* changing themes in room editor changes the background color of the tileset view ([e898a15](https://github.com/ConConner/MAGE-Themes/commit/e898a153d0af52854c85c3ddd0b7d56f3f8433d2))
* credits editor crashes if no text is commited in an edit ([31b90ca](https://github.com/ConConner/MAGE-Themes/commit/31b90caf32e0cd07bc8405e147653238078170d7))
* credits editor documentation missing ([9a1cebf](https://github.com/ConConner/MAGE-Themes/commit/9a1cebfbc249ead9d1f9d533ddb4647eef2c179e))
* help viewer does not follow links to internal documentation correctly ([497e819](https://github.com/ConConner/MAGE-Themes/commit/497e81934f511c887da7ff6be510343c368bf371))
* help viewer theming results in illegible headers ([e3b2342](https://github.com/ConConner/MAGE-Themes/commit/e3b23423e796500ba04a9f417dccc25167460376))

# [1.9.0](https://github.com/ConConner/MAGE-Themes/compare/v1.8.0...v1.9.0) (2025-09-26)


### Bug Fixes

* buttons on the "new update available" form do not scale correctly ([cd58920](https://github.com/ConConner/MAGE-Themes/commit/cd5892011862fec1ce8ee32bd3a61046b499ea95))
* demo test does not respect TestRom path ([8e953d6](https://github.com/ConConner/MAGE-Themes/commit/8e953d6e44e39138cc28d3b9f98e226aef9641f8))


### Features

* add unsaved changes check to sprite editor ([840ac9b](https://github.com/ConConner/MAGE-Themes/commit/840ac9b1678608db6796b821b5da29b451aa8d15))
* added credits editor ([d8d0766](https://github.com/ConConner/MAGE-Themes/commit/d8d0766af8a88fc675a3033d2db003526e028c9f))
* added outlines to the tilesets in the tileset dialog ([374936c](https://github.com/ConConner/MAGE-Themes/commit/374936cee794d71332066a50d4ee3557b23588e1))
* import and export credits compatible with ConCons Credits Crediter ([7cbf53d](https://github.com/ConConner/MAGE-Themes/commit/7cbf53d2c18f786db129ecbbf72271f5040129d8))
* modify freezing resistance for ZM in the sprite editor ([d070fdd](https://github.com/ConConner/MAGE-Themes/commit/d070fddabdb63f2a53382eb5c48e0a327c08edea))
* moved bookmarks button from "Options" to "Tools" ([0ae574b](https://github.com/ConConner/MAGE-Themes/commit/0ae574b6e537e06d4fc50d9fa9d5aca0a4af6158))
* update docs ([9963347](https://github.com/ConConner/MAGE-Themes/commit/99633470191bc32dbfb1a7ac609360d8cfdb26e5))

# [1.8.0](https://github.com/ConConner/MAGE-Themes/compare/v1.7.0...v1.8.0) (2025-09-18)


### Bug Fixes

* oam editor: palette loading can lead to an out of bounds error ([a405b58](https://github.com/ConConner/MAGE-Themes/commit/a405b58eaf691356bdf7dea58ea1c1a07b331bf4))


### Features

* display room outlines in the map editor [experimental] ([1851882](https://github.com/ConConner/MAGE-Themes/commit/185188293328b92f274cf0b8cacae9228b2c6adf))
* new map editor [experimental] ([24eec3a](https://github.com/ConConner/MAGE-Themes/commit/24eec3aaed57dd88bcfa71751a419eb0626794dc))
* renamed "Minimap Editor" to "Map Editor" ([4793e14](https://github.com/ConConner/MAGE-Themes/commit/4793e14c8c8c4974dab618fc2efa1045479568a4))
* renamed "Minimap Tile Builder" to "Map Tile Builder" ([f623761](https://github.com/ConConner/MAGE-Themes/commit/f62376138ab82cdfc9e94edb872885fe51985b54))
* resizeable panels display a handle ([462ab82](https://github.com/ConConner/MAGE-Themes/commit/462ab8238d9e7b464d0841c058222e24c58e62fb))
* room editor layout changes: tileset display can be resized ([9d42740](https://github.com/ConConner/MAGE-Themes/commit/9d42740dc39106cd25b39b923cb72d13a9316109))
* toggle usage of common sprite graphics in oam editor ([b090c0e](https://github.com/ConConner/MAGE-Themes/commit/b090c0efdbad7249f635733ac0cc76588ca5ab57))
* zoom in room editor tileset ([716145e](https://github.com/ConConner/MAGE-Themes/commit/716145e7949044a743574e8f9a9569f0175da040))

# [1.7.0](https://github.com/ConConner/MAGE-Themes/compare/v1.6.0...v1.7.0) (2025-09-14)


### Features

* add elevator shortcuts to clipdata shortcuts ([8d52a50](https://github.com/ConConner/MAGE-Themes/commit/8d52a5020c7675cfcf2883ed3e24ab99e1bc4432))
* added hatches to clipdata shortcuts ([7af22d5](https://github.com/ConConner/MAGE-Themes/commit/7af22d57f097f3012b99f3db5a097126ce6e546e))
* choose whether to check for updates ([dde1b4d](https://github.com/ConConner/MAGE-Themes/commit/dde1b4d31f436b2e08e334d615185597b32f6ab9))
* rearranged clipdata shortcuts ([d122c0b](https://github.com/ConConner/MAGE-Themes/commit/d122c0b3c361b477cef5bc7255f02eda1520857b))

# [1.6.0](https://github.com/ConConner/MAGE-Themes/compare/v1.5.1...v1.6.0) (2025-09-11)


### Bug Fixes

* values of internal bookmarks can't be highlighted with the mouse ([f775444](https://github.com/ConConner/MAGE-Themes/commit/f77544494c0df89c710ca44255bc2859dbaeb053))
* version string contains a trailing 0 in about page ([a169c7a](https://github.com/ConConner/MAGE-Themes/commit/a169c7abfe6023263f32de28e4883bbaf490d361))


### Features

* "save with ctrl+s" and more shortcuts added ([9d2e399](https://github.com/ConConner/MAGE-Themes/commit/9d2e399954802ac54053c516a96a107ec03742d8))
* add icons to the menu bar items ([3684e50](https://github.com/ConConner/MAGE-Themes/commit/3684e5040078227f5de1193a102eec26c3a73e49))
* add multiple emulators and choose between them ([437ee80](https://github.com/ConConner/MAGE-Themes/commit/437ee80c8971a2bbf61654ae66e3d16b1ff2b416))
* change Test-ROM path ([31eeca8](https://github.com/ConConner/MAGE-Themes/commit/31eeca8d54849c55480ac72ae9d4562fc229855b)), closes [#22](https://github.com/ConConner/MAGE-Themes/issues/22)
* choose to include symbol file with Test-ROM ([7fd0e8d](https://github.com/ConConner/MAGE-Themes/commit/7fd0e8db6451cebba6677f28798920b6835d17a2))
* new options menu ([88fcfca](https://github.com/ConConner/MAGE-Themes/commit/88fcfca9a6013f0ef50c52fa0d2700a480a5408b))

## [1.5.1](https://github.com/ConConner/MAGE-Themes/compare/v1.5.0...v1.5.1) (2025-08-23)


### Bug Fixes

* bookmarks do not get dropped off at the desired location ([6fc9b67](https://github.com/ConConner/MAGE-Themes/commit/6fc9b6786ee14dfa3df6183480c88da0d356027a))

# [1.5.0](https://github.com/ConConner/MAGE-Themes/compare/v1.4.0...v1.5.0) (2025-08-22)


### Bug Fixes

* oam editor now properly opens default OAM even if repointed ([e515853](https://github.com/ConConner/MAGE-Themes/commit/e515853c6b90193355e6e264cecc195b32730161))
* oam editor: removed unused menu bar ([6fb166c](https://github.com/ConConner/MAGE-Themes/commit/6fb166c55531843acb6c78b38df261f2eaa97cc5))
* OAM repointing now saves repointed sprites in the project file ([8deb2fa](https://github.com/ConConner/MAGE-Themes/commit/8deb2fa553d211b37cbc35bfb95b2203290349f1))
* outlines of text boxes behave correctly ([d70f8a6](https://github.com/ConConner/MAGE-Themes/commit/d70f8a66f0bb818a33ba521f7c5d383931c997e4))
* weapon editor: controls visually overlapping ([37fadda](https://github.com/ConConner/MAGE-Themes/commit/37fadda4a817f5739c695bb2c6c58654efb1a6b9))


### Features

* bookmarking feature, create bookmarks to store offsets ([f06a91a](https://github.com/ConConner/MAGE-Themes/commit/f06a91abbc2e5ccd5d24dd3176da934091767779))
* repointed resources get saved in bookmarks ([842f108](https://github.com/ConConner/MAGE-Themes/commit/842f108fcbff3372802eccaf176fdc03d7dcaeba))

# [1.4.0](https://github.com/ConConner/MAGE-Themes/compare/v1.3.0...v1.4.0) (2025-08-14)


### Bug Fixes

* oam editor no longer crashes after playing an animation and selecting a part ([5294e31](https://github.com/ConConner/MAGE-Themes/commit/5294e3123235af4c4a7d80a93e6ddbdbc3fba498))
* oam editor no longer crashes after removing a frame and saving ([fd9fc31](https://github.com/ConConner/MAGE-Themes/commit/fd9fc314317b21065992427455c70ae62f277ee2))


### Features

* export and import OAM from and to MAGE ([f85b9d1](https://github.com/ConConner/MAGE-Themes/commit/f85b9d1852784987cf47949bfcac2d0e8911968b))
* export OAM as animated .gif ([27b19d1](https://github.com/ConConner/MAGE-Themes/commit/27b19d152fdb42a195a37ed12596b4e2d8ce7361))
* export OAM as assembly ([27fcca7](https://github.com/ConConner/MAGE-Themes/commit/27fcca70fa01c1ec232ff8d712be4d487c0d4aac))

# [1.3.0](https://github.com/ConConner/MAGE-Themes/compare/v1.2.0...v1.3.0) (2025-07-24)


### Bug Fixes

* adjust about page ([acc8fe6](https://github.com/ConConner/MAGE-Themes/commit/acc8fe63863594321e8bd5d0c987273c592d3663))
* data would sometimes not be four byte aligned ([7e954e3](https://github.com/ConConner/MAGE-Themes/commit/7e954e3e4ae00392e7c3eaa30424dc9233e0852b))


### Features

* added settings to area image export ([e771003](https://github.com/ConConner/MAGE-Themes/commit/e77100380c9307909849459d3f080123273abcdc))
* use shift+scroll to scroll horizontally ([6a4a112](https://github.com/ConConner/MAGE-Themes/commit/6a4a112d85c354c4a902e2c3caf02a3b99cb6a94))

# [1.2.0](https://github.com/ConConner/MAGE-Themes/compare/v1.1.0...v1.2.0) (2025-07-20)


### Features

* add legacy documentation for old editors ([1f6ca93](https://github.com/ConConner/MAGE-Themes/commit/1f6ca931795bf025a38ed549b1ef7b5a9f4f055e))
* added documentation for the new tile table editor ([5112d25](https://github.com/ConConner/MAGE-Themes/commit/5112d2514bc5d83f072ed990315eb4432d7865b5))
* adjusted clipdata naming and font spacing (alexman25) ([dcb1ab4](https://github.com/ConConner/MAGE-Themes/commit/dcb1ab4603fb226811c5711307c868dbd990dfb9))
* automatic update check ([9f60048](https://github.com/ConConner/MAGE-Themes/commit/9f60048eb72d771b6998a643a5f959eeb0fa26c1))

# [1.1.0](https://github.com/ConConner/MAGE-Themes/compare/v1.0.1...v1.1.0) (2025-07-17)


### Bug Fixes

* quick theme switcher is now always enabled ([c7ffae3](https://github.com/ConConner/MAGE-Themes/commit/c7ffae3960d924ef7976d45e4efd9fa98bd592db))


### Features

* context menus are themed ([d453df4](https://github.com/ConConner/MAGE-Themes/commit/d453df4f326b246afdc7f8cfeffa501f9783291e))
* new help viewer ([b6ec802](https://github.com/ConConner/MAGE-Themes/commit/b6ec8020b05f288cabffae2ed1cfb356d12bb809))
* tile table editor moved out of experimental features ([29db761](https://github.com/ConConner/MAGE-Themes/commit/29db761f45edc22a25cff82ce167149ba912f215))

## [1.0.1](https://github.com/ConConner/MAGE-Themes/compare/v1.0.0...v1.0.1) (2025-07-16)


### Bug Fixes

* remove new helpviewer for new implementation later on ([65868a8](https://github.com/ConConner/MAGE-Themes/commit/65868a89588c1b2fa715745794a935c1445a9961))

# 1.0.0 (2025-07-16)


### Bug Fixes

* auto setup ([2634db3](https://github.com/ConConner/MAGE-Themes/commit/2634db30cef955d7268cf15c7fa0511942cbf99b))
* crash on auto door setup ([acf651e](https://github.com/ConConner/MAGE-Themes/commit/acf651e612c016d86eba6eeb66fa87fc0dde47b5))
