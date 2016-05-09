using UnityEngine;
using System.Collections;

public class CharacterDeplacement : MonoBehaviour {


    public float m_AccelerometerLimit;
    public float m_AccelerometerSensibility;

    public float m_MaxSpeed;


	// Use this for initialization
	void Start ()
    {
        // On limite la prise en compte de l'accéléromètre du téléphone, qui retourne une valeur entre -1 et 1.
        // Cette valeur est pour l'instant en public pour être modifiée dans l'Inspector avant validation.
        // m_AccelerometerLimit = 0.2f;

        // On détermine une zone de sensibilité dans laquelle le personnage ne se déplace pas.
        // Cette valeur est pour l'instant en public pour être modifiée dans l'Inspector avant validation.
        // m_AccelerometerSensibility = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        #region Input accéléromètre
        float _currentPercentSpeed;
        float _currentSpeed;

        // On calcule le pourcentage d'inclinaison du téléphone (clampé entre 0 et 100) par rapport à l'inclinaison maximale (pour savoir à quel point le joueur incline le téléphone)
        _currentPercentSpeed = Mathf.Clamp(((Input.acceleration.x / m_AccelerometerLimit) * 100), -100, 100);

        // La vitesse actuelle du personnage correspond au pourcentage d'inclinaison du téléphone reporté sur la vitesse maximale
        // (Si j'incline mon téléphone à 50% de l'inclinaison maximale, mon personnage va à 50% de la vitesse maximale)
        _currentSpeed = m_MaxSpeed * (_currentPercentSpeed / 100);


        // Si le téléphone est penché sur la droite et ne se trouve pas dans la zone de sensibilité...
        if (Input.acceleration.x > m_AccelerometerSensibility || Input.acceleration.x < m_AccelerometerSensibility)
        {
            transform.position += new Vector3(_currentSpeed, 0, 0) * Time.deltaTime;
        }
        #endregion
        

        #region Input clavier

        // Si le joueur appuie sur l'une de ces touches
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // Le personnage se déplace de la vitesse maximale (pas de mouvement progressif avec le clavier)
            transform.position -= m_MaxSpeed * Vector3.right * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += m_MaxSpeed * Vector3.right*Time.deltaTime;
        }
        #endregion
    }
}
