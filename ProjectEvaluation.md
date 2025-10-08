# Project Review and Suggestions

## 1. Evaluation

### Advantages
- Code structure is clear and easy to follow.  
- Functions are logically grouped by feature.  
- The game runs relatively smoothly and efficiently. 

### Disadvantages
- Some functions lack null-checks, which may cause runtime errors.  
- A few functions risk infinite loops due to missing exit conditions.  
- Text updates are executed every frame, which is unnecessary and affects performance.

---

## 2. Suggestions for Improvement

###  Add Null Checks
Add `null` validation for critical objects or parameters before accessing them to prevent crashes and improve stability.
```c#
public eStateGame State
{
    get { return m_state; }
    private set
    {
        m_state = value;
        StateChangedAction?.Invoke(m_state);
    }
}
```

###  Merge Functions
Combine functions with similar logic to reduce redundancy and make maintenance easier.
-ShiftDownItemsCoroutine(), RefillBoardCoroutine(), và ShuffleBoardCoroutine() have same structure
```c#
private IEnumerator BoardRoutine(Action firstAction, float firstDelay, Action secondAction = null, float secondDelay = 0.2f)
{
    firstAction?.Invoke();
    yield return new WaitForSeconds(firstDelay);

    secondAction?.Invoke();
    yield return new WaitForSeconds(secondDelay);

    FindMatchesAndCollapse();
}
```
###  Prevent Infinite Loops
Review looping conditions and ensure there are valid exit conditions to avoid potential infinite loops.
- FindMatchesAndCollapse - CollapseMatches - ShiftDownItemsCoroutine - FindMatchesAndCollapse
###  Split Interfaces
Separate interfaces by responsibility (Single Responsibility Principle) to make implementation classes more modular and testable.(LevelCondition Void virtual Setup)

###  Optimize Text Updates
Change text updates from “every frame” to “only when the text value changes” to improve performance.
(on LevelTime , void Update())
```c#
private int prevTime;
private void Update()
{
    ...
    m_time -= Time.deltaTime;
    int currentTime = Mathf.CeilToInt(m_time);
    if(m_time != prevTime)
    {
        prevTime = m_time;
        UpdateText();
    }
}

---