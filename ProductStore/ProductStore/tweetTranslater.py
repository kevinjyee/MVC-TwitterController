import pandas as pd



def readMilestones():
    df = pd.read_csv("data/trump_tweets.csv", names = ['UserName', 'Date', 'Tweets']);
    UserName = df['UserName'].tolist()
    Date = df['Date'].tolist()
    Tweets = df['Tweets'].tolist()


    for i in range(len(UserName)):
        #print "milestonesInfo.Add(new MilestonesInfo {MonthDue =", Month[i], ",CategoryName = ", '"%s"'%Category[i], ", CategoryDescription = ",'"%s"'%Description[i], "});"
        print "Add(new Product { Name = ",'"%s"'%UserName[i],", Category = ",'"%s"'%Date[i],", Price =", '"%s"'%Tweets[i],"});"
if __name__ == "__main__":
  # readInCSV()
    readMilestones();