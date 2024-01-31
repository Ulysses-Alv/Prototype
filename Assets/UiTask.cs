using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiTask : MonoBehaviour
{
    [SerializeField] private Tarea[] tareas;

    [SerializeField] TextMeshProUGUI descripcion, expDate;
    [SerializeField] Toggle isCompleted;
    [SerializeField] private Button nextButton;

    int numberTask;
    private void Awake()
    {
        nextButton.onClick.AddListener(ChangeNextTarea);
    }


    private void ChangeNextTarea()
    {
        Tarea tarea = GetNextTarea();
        ReplaceUI(tarea);
    }

    private Tarea GetNextTarea()
    {
        numberTask++;

        if (numberTask >= tareas.Length)
        {
            numberTask = 0;
        }
        Tarea result = tareas[numberTask];
        return result;
    }

    private void ReplaceUI(Tarea tarea)
    {
        descripcion.text = tarea.description;
        expDate.text = $"{tarea.expDate}";
        isCompleted.isOn = tarea.isCompleted;
    }
}



[System.Serializable]
public class Tarea
{
    public string description;
    public bool isCompleted;
    public int expDate;
}
