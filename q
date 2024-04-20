[33mcommit e1744331968c829ede6789e090d728f48dd26556[m[33m ([m[1;36mHEAD -> [m[1;32mtest[m[33m)[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Fri Apr 19 21:57:41 2024 +0800

    Try to refactor Item hierarchy system to use method hiding approach instead of generic approach

[33mcommit 71e09087328b53544ed249510e41cb125ae45cca[m[33m ([m[1;32mmain[m[33m)[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Fri Apr 19 20:45:15 2024 +0800

    Add DropItem method

[33mcommit 1f86621dba5e4b00ee82d659293a4d2a4fe5538f[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Fri Apr 19 15:01:44 2024 +0800

    Allow player to select weapon using number keys

[33mcommit 96ce870544d48bd07eecc43d4a82064c7887bf33[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Fri Apr 19 14:48:49 2024 +0800

    Add pickUpPrefab field to ItemData

[33mcommit cdc079063aa7072fd9e23d2b64b1b4b9eaf56ab8[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Fri Apr 19 14:17:12 2024 +0800

    Refactor the inheritance system between ItemData, ItemInstance and ItemPickUp along with their subclasses

[33mcommit ec35b1c3de1bf26f8f3edcac958d9af70ea4a4b3[m[33m ([m[1;31morigin/main[m[33m)[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Thu Apr 18 23:05:56 2024 +0800

    Create InventoryManager class which is responsible for deciding which inventory to add to

[33mcommit 555b748a5925e26eb48533b8e6c8f81e4b726879[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Thu Apr 18 22:25:21 2024 +0800

    Implement adding of items to inventory when interact with ItemPickUp

[33mcommit 4d1d6592124903f3bc9990d45505da3ad721b5fc[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Thu Apr 18 22:00:58 2024 +0800

    Change InteractSystem to monobehaviour (again!), so it can be responsible for handling inputs related to interactions

[33mcommit 5026bb3751f6bf5bfdbb9b664596e677a692db6b[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Thu Apr 18 21:47:03 2024 +0800

    Separate PlayerMovement from PlayerController
    Refactor InteractSystem into a normal class and not a monobehaviour

[33mcommit 9cda4f0215d2e9538215139bb2013139bc6f3398[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Thu Apr 18 21:02:38 2024 +0800

    Create Inventory abstract class

[33mcommit 401c6ee7ad57c1d072fbb4601469facc649dc3a8[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Thu Apr 18 13:03:12 2024 +0800

    Refactor relationship between Interactable and InteractSystem
    Use trigger colliders to determine whether interactable object is in range of player
    Interactable objects subscribe to changes in the Target property of the player's InteractSystem, to determine whether to show or hide the interact prompt

[33mcommit 7dbb51bd744a6a3fd01ebccb61131105984baf4f[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Thu Apr 18 11:44:58 2024 +0800

    Refactor relationships between ItemData, ItemInstance and ItemPickUp, and associates subclasses
    Create scriptable objects to contain data for Plasma Gun and Laser Gun, and attach this data to their corresponding ItemPickUp gameobjects

[33mcommit bc8ce68f66fa7e3579745338d2d3d79c9d4622bb[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Wed Apr 17 21:01:37 2024 +0800

    Create ItemData and ItemInstance base classes, which other items like weapons and armors will inherit from.
    ItemData contains base values and metadata that is consistent across all instances of the item, while ItemInstance contains variable fields for each instance of the item, independent of all other instances of that item

[33mcommit a93775a34dd223c955f956b2718b4f1f29ca288b[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Wed Apr 17 15:06:24 2024 +0800

    Integrate the methods for picking up, dropping and switching weapons

[33mcommit 8b776e12f156227b287a8ac6721b97b48bfdd7c0[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Wed Apr 17 13:42:02 2024 +0800

    Implement maxWeapons limit

[33mcommit c6e74466e101d971ea2b8ec30b1c9af79bcc125e[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Wed Apr 17 13:34:35 2024 +0800

    Implement weapon switching using number keys

[33mcommit 1aa569af8a12764caebdd13c6db3166ffcf5fd2d[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Wed Apr 17 13:17:26 2024 +0800

    Implement adding and equipping of weapons

[33mcommit a519844bbd24f2bd452454e8323d2fdfca5c15e8[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Wed Apr 17 10:39:24 2024 +0800

    Create Interactable class and implement interact system
    Interact system is used by WeaponPickUps
    Implement picking up and dropping of weapons

[33mcommit 19388651af57b26631dd8c81128a25809e2c98ae[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Tue Apr 16 22:30:24 2024 +0800

    Implement weapon pickup logic

[33mcommit 7757e94109f2b46d8dfed63b1f37d6d98a27b3b6[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Tue Apr 16 21:33:50 2024 +0800

    Implement targeting system for pick-up items

[33mcommit f308edcb4f9858119cf896c0c9f7cc4013fe3246[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Tue Apr 16 14:37:17 2024 +0800

    Add dash

[33mcommit ef95ffb153e0768bf950a76b20a34b59e8a132bf[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Tue Apr 16 14:28:58 2024 +0800

    Add code to flip player sprite when changing direction

[33mcommit 44800c12d85f0555395df19c82175c2a8ba7eeea[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Tue Apr 16 13:29:33 2024 +0800

    Implement basic player controls: movement and shooting

[33mcommit 92bc0cb36a8b2ce9e71d316e84d1f76b4c52369a[m
Author: Glenn Chiang <glennchiang24@gmail.com>
Date:   Tue Apr 16 10:41:51 2024 +0800

    Initial commit
