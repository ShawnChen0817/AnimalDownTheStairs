from attr import s
import mysql.connector
import cv2
import numpy as np
connection = mysql.connector.connect(host='127.0.0.1',
                                     port= '3306',
                                     user='root',
                                     password='aqz10431123',
                                     database = 'sql_test')

cursor = connection.cursor()

#創建資料庫
##cursor.execute("CREATE DATABASE `qq`;")

#取得資料庫名稱
cursor.execute("SELECT * FROM `Branch`;")
records = cursor.fetchall() 
for r in records:
    print(r)

#存放圖片

#讀取資料庫圖片
cursor.execute("SELECT data FROM `binary_data` WHERE id=1")
fout = open("upload test.zip",'wb')
fout.write(cursor.fetchone()[0])
fout.close()
cursor.close()
connection.close()




