AZUREPAT=$AZUREPAT
AZUSERNAME=$AZUSERNAME
AZUSER_EMAIL=$AZUSER_EMAIL
AZORG=$AZORG
GHUSER=$GHUSER
GHPAT=$GHPAT

git config --global user.email "$AZUSER_EMAIL"
git config --global user.name "$AZUSERNAME"

git clone https://$GHUSER:$GHPAT@github.com/saigkill/Moonglade ./Moonglade-gh
GIT_CMD_REPOSITORY="https://$AZUSERNAME:$AZUREPAT@dev.azure.com/$AZORG/Moonglade/_git/Moonglade"
git clone $GIT_CMD_REPOSITORY ./Moonglade-az

cd Moonglade-az
rm -rf .git
cd ..

cp -r Moonglade-az/* Moonglade-gh/

pushd Moonglade-gh

git add .
git commit -m "sync prod from azure to github"
git push

popd
