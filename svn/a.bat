rem data/facw/svn co http://code.taobao.org/svn/yxgcipup/trunk ./data/facw
rem "data/facw/svn.exe" co http://code.taobao.org/svn/yxgcipup/trunk ./data/facw/sl
rem "./data/facw/svn.exe"  co  "http://code.taobao.org/svn/yxgcipup/trunk"  "./data/facw/sl"

rem "data/facw/svn" add ./data/facw/sl/sl.txt
"data/facw/svn" ci ./data/facw/sl -m "new" --username ipuppublic --password 1234abcD
pause