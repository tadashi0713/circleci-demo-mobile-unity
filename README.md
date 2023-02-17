# circleci-demo-mobile-unity

[![CircleCI](https://dl.circleci.com/status-badge/img/gh/tadashi0713/circleci-demo-mobile-unity/tree/master.svg?style=svg)](https://dl.circleci.com/status-badge/redirect/gh/tadashi0713/circleci-demo-mobile-unity/tree/master)

Demo for mobile game CI/CD pipeline of Unity using CircleCI.

<img width="1456" alt="スクリーンショット 2022-09-20 13 01 18" src="https://user-images.githubusercontent.com/8651308/191164693-8827fca5-6405-45cf-93dd-1c4cd941bf16.png">

## Features

* This 

* Custom 
  * 

<img width="1102" alt="スクリーンショット 2022-09-20 13 27 37" src="https://user-images.githubusercontent.com/8651308/191167569-4d00203b-2384-4dcd-a722-1020cb8ee42c.png">

## Activate 

## Android build pipeline

```yaml
jobs:
  build-android:
    executor:
      name: unity/ubuntu
      editor_version: 2021.3.9f1
      resource_class: xlarge
      target_platform: android
    steps:
      - checkout
      - unity/prepare-env
      - unity/build:
          build-target: Android
          compress: false
          store-artifacts: false
      - persist_to_workspace:
          root: .
          paths:
            - Builds/Android

  beta-android:
    docker:
      - image: cimg/ruby:3.1.2
    steps:
      - checkout
      - attach_workspace:
          at: .
      - ruby/install-deps:
          key: android
      - run: bundle exec fastlane android beta
```



## iOS build pipeline

```yaml
jobs:
  export-ios:
    executor:
      name: unity/ubuntu
      editor_version: 2021.3.9f1
      resource_class: xlarge
      target_platform: ios
    steps:
      - checkout
      - unity/prepare-env
      - unity/build:
          build-target: iOS
          compress: false
          store-artifacts: false
      - persist_to_workspace:
          root: .
          paths:
            - Builds/iOS/iOS

  build-and-beta-ios:
    macos:
      xcode: 13.4.1
    resource_class: large
    steps:
      - checkout
      - attach_workspace:
          at: .
      - ruby/install-deps:
          key: ios
      - run: bundle exec fastlane ios beta
```

## About demo Unity project

![](https://blog-api.unity.com/sites/default/files/2019/12/sara_lights_shadow-scaled.png)



https://assetstore.unity.com/packages/essentials/tutorial-projects/lost-crypt-2d-sample-project-158673

You can download 

https://blog.unity.com/technology/download-our-new-2d-sample-project-lost-crypt
