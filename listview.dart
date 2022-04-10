import 'package:flutter/material.dart';

class List extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: Color(0xff2c2f33),
        appBar: AppBar(
          elevation: 0,
          backgroundColor: Color(0xff2c2f33),
          leading: IconButton(
            onPressed: () {
              Navigator.pop(context);
            },
            icon: Icon(Icons.arrow_back_ios,
              size: 20,
              color: Colors.white70),
          ),
        ),
      body: ListView(
        children: [
          Container(
            child: ListTile(
              textColor: Colors.white,
              title: Text("text1"),
              subtitle: Text("sub"),
              onTap: (){},
            ),
          ),
          Container(
            child: ListTile(
              textColor: Colors.white,
              title: Text("text2"),
              subtitle: Text("sub"),
              onTap: (){},
            ),
          ),
          Container(
            child: ListTile(
              textColor: Colors.white,
              title: Text("text3"),
              subtitle: Text("sub"),
              onTap: (){},
            ),
          )
        ],
      )
    );
  }
}
