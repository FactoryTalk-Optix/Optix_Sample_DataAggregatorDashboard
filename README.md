# Data aggregator dashboard

This projects emulates a dashboard for a data aggregator application. User can add custom trends (types) that can be configured to read specific columns of specific tables.

## Preparing the demo

This demo can run without any external tools

### Concept

- A script, called `FakeMQTTLogic` emulates receiving data from a third party (like an MQTT broker) and puts the received data in a Store object
- A `WidgetWithTrend` type can be instantiated as many times as needed passing the table name (`Line1`, `Line2` and `Line3`) and the column that should be rendered (`Speed` or `Counter`)

## Cloning the repository

There are multiple ways to download this project, here are few of them

### Clone repository
1. Click on the green `CODE` button in the top right corner
2. Select `HTTPS` and copy the provided URL
3. Open FT Optix IDE
4. Click on `Open` and select the `Remote` tab
5. Paste the URL from step 2
6. Click `Open` button in bottom right corner to start cloning process

## Disclaimer

Rockwell Automation maintains these repositories as a convenience to you and other users. Although Rockwell Automation reserves the right at any time and for any reason to refuse access to edit or remove content from this Repository, you acknowledge and agree to accept sole responsibility and liability for any Repository content posted, transmitted, downloaded, or used by you. Rockwell Automation has no obligation to monitor or update Repository content

The examples provided are to be used as a reference for building your own application and should not be used in production as-is. It is recommended to adapt the example for the purpose, observing the highest safety standards.
