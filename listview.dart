import 'package:flutter/material.dart';

class List extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          elevation: 0,
          backgroundColor: Colors.white,
          leading: IconButton(
            onPressed: () {
              Navigator.pop(context);
            },
            icon: Icon(Icons.arrow_back_ios,
              size: 20,
              color: Colors.black,),
          ),
        ),
      body: ListView(
        children: [
          Container(
            child: ListTile(
              title: Text("text1"),
              subtitle: Text("sub"),
              onTap: (){},
            ),
          ),
          Container(
            child: ListTile(
              title: Text("text2"),
              subtitle: Text("sub"),
              onTap: (){},
            ),
          ),
          Container(
            child: ListTile(
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