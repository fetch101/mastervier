using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IView {

    void drawLines();

    void destroyLines();
    
    void alignContents(List<Content> contentList);
	
}
