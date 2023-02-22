AZUREPAT=$AZUREPAT
AZUSERNAME=$AZUSERNAME
AZUSER_EMAIL=$AZUSER_EMAIL
AZORG=$AZORG
git clone https://github.com/saigkill/Moonglade ./Moonglade-gh
cd Moonglade-gh
rm -rf .git

cd ..

GIT_CMD_REPOSITORY="https://$AZUSERNAME:$AZUREPAT@dev.azure.com/$AZORG/Moonglade/_git/Moonglade"
git clone $GIT_CMD_REPOSITORY ./Moonglade-az

cp -r Moonglade-gh/* Moonglade-az/

cd Moonglade-az

git config --global user.email "$AZUSER_EMAIL"
git config --global user.name "$AZUSERNAME"

git add .
git commit -m "sync from git to azure"

git push

git checkout develop
git merge master develop

git add .
git commit -m "sync from git to azure"

git push