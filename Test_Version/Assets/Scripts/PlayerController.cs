using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    internal GameObject _weapon;
    private Rigidbody2D _playerRigidbody;
    private Animator _playerAnimator;

    private float _moveSpeed = 300f;
    private float _jumpForce = 500f;
    private float _xInput;
    private float Timer = 0f;

    private int _jumpCount;

    private bool _death;
    private bool _jumpping;
    private bool _weaponUp;
    private bool _dashing;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();

        _jumpCount = 0;
        _death = false;
        _jumpping = false;
        _weaponUp = true;
        _dashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        PlayerAnimation();
        Attack();
        if (!_jumpping)
        {
            Dash();
            Timer += Time.deltaTime;
            if (Timer > 5f)
            {
                _dashing = false;
                Timer = 0f;
            }
        }
    }

    // 이동
    public void Move()
    {

        _xInput = Input.GetAxis("Horizontal");
        float _playerSpeed = _xInput * _moveSpeed * Time.deltaTime;

        Vector2 NewVector = new Vector2(_playerSpeed, _playerRigidbody.velocity.y);
        _playerRigidbody.velocity = NewVector;

        if (_xInput < 0) // 왼쪽
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (_xInput > 0) // 오른쪽
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            _playerSpeed = 0;
        }
    }

    // 점프
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _jumpCount < 2)
        {
            _jumpCount++;

            _playerRigidbody.velocity = Vector2.zero;
            _playerRigidbody.AddForce(Vector2.up * _jumpForce);
        }
    }
    public void PlayerAnimation()
    {
        if (_xInput != 0 && _jumpping == false)
        {
            _playerAnimator.SetBool("SetMove", true);
            _playerAnimator.SetBool("SetJump", false);
            _playerAnimator.SetBool("SetIdle", false);
        }
        else if (_xInput == 0 && _jumpping == false)
        {
            _playerAnimator.SetBool("SetMove", false);
            _playerAnimator.SetBool("SetJump", false);
            _playerAnimator.SetBool("SetIdle", true);
        }
        else if (_jumpping || (_xInput == 0 && _jumpping))
        {
            _playerAnimator.SetBool("SetMove", false);
            _playerAnimator.SetBool("SetJump", true);
            _playerAnimator.SetBool("SetIdle", false);
        }
    }

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.X) && !_dashing )
        {
            _moveSpeed = 900f;
            _dashing = true;
            Invoke("DashOff", 1f);
        }
    }

    public void DashOff()
    {
        _moveSpeed = 300f;
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (_weaponUp)
            {
                _weapon.GetComponent<SpriteRenderer>().flipY = true;
                _weaponUp = false;
            }
            else
            {
                _weapon.GetComponent<SpriteRenderer>().flipY = false;
                _weaponUp = true;
            }
        }
    }

    public void Defense()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            _jumpCount = 0;
            _jumpping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            _jumpping = true;
        }
    }
}
